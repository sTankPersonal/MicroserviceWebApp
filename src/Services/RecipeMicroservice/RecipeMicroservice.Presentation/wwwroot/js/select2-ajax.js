$(function () {
    $('.select2-field').each(function () {
        const $select = $(this);
        const url = $select.data('ajax-url');
        const idField = $select.data('ajax-id-field');
        const textField = $select.data('ajax-text-field');
        const rawPayload = $select.attr('data-ajax-payload');
        const payloadMap = rawPayload ? JSON.parse(rawPayload) : {};

        $select.select2({
            placeholder: $select.data('placeholder'),
            ajax: {
                url: url,
                dataType: 'json',
                delay: 250,
                data: function (params) {
                    const payload = {};
                    $.each(payloadMap, function (key, value) {
                        if (typeof value !== 'string') {
                            payload[key] = value;
                            return;
                        }
                        if (value === 'term') {
                            payload[key] = params.term || '';
                        } else if (value === 'page') {
                            payload[key] = params.page || 1;
                        } else if (value.startsWith('#')) {
                            payload[key] = $(value).val();
                        } else {
                            payload[key] = value;
                        }
                    });
                    return payload;
                },
                processResults: function (data) {
                    const items = Array.isArray(data) ? data : (data.results || []);
                    return {
                        results: items.map(function (item) {
                            return {
                                id: item[idField],
                                text: item[textField]
                            };
                        }),
                        pagination: data.pagination || {}
                    };
                }
            }
        });

        // This is the important fix
        $select.on('select2:select', function (e) {
            const data = e.params.data;

            // Remove previous selections (important if single-select)
            $select.find('option').prop('selected', false);

            // Add or update the option element
            let $option = $select.find('option[value="' + data.id + '"]');
            if ($option.length === 0) {
                $option = new Option(data.text, data.id, true, true);
                $select.append($option);
            } else {
                $option.prop('selected', true);
            }

            // 🧩 Manually set the value and trigger change on the real <select>
            $select.val(data.id).trigger('change.select2');
        });
    });
});
