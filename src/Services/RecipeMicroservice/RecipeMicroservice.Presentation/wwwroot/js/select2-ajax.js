$(function () {
    $('.select2-field').each(function () {
        const $select = $(this);
        const preselectedId = $select.val();
        const listUrl = `${$select.data('ajax-url')}/List`;
        const singleUrl = `${$select.data('ajax-url')}/${preselectedId}`;
        const idField = $select.data('ajax-id-field');
        const textField = $select.data('ajax-text-field');
        const rawPayload = $select.attr('data-ajax-payload');
        const payloadMap = rawPayload ? JSON.parse(rawPayload) : {};

        $select.select2({
            placeholder: $select.data('placeholder'),
            ajax: {
                url: listUrl,
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
            },
            templateSelection: function (data) {
                if (data.id && !$select.find("option[value='" + data.id + "']").length) {
                    const option = new Option(data.text, data.id, true, true);
                    $select.append(option).trigger('change');
                }
                return data.text || data.id;
            }
        });

        if (preselectedId && singleUrl) {
            $.ajax({
                url: `${singleUrl}/${preselectedId}`,
                dataType: 'json'
            }).then(function (item) {
                if (item) {
                    const option = new Option(item[textField], item[idField], true, true);
                    $select.append(option).trigger('change');
                }
            }).catch(function (err) {
                console.warn('Failed to prepopulate select2', err);
            });
        }
    });
});
