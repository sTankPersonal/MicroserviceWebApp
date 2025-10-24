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
            //tags: true, // Allow new entries
            //createTag: function (params) {
            //    return {
            //        id: params.term,
            //        text: params.term,
            //        newOption: true
            //    };
            //},
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
                            payload[key] = $(value).val(); // reference another input
                        } else {
                            payload[key] = value; // static string
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
        //}).on('select2:select', function (e) {
        //    var data = e.params.data;
        //    if (data.newOption) {
        //        // Call your Razor Page route to add the new entry
        //        $.ajax({
        //            url: '/YourPage/AddNewEntry', // Update with your route
        //            method: 'POST',
        //            data: { name: data.text },
        //            success: function (response) {
        //                // Optionally update the select2 options
        //            }
        //        });
        //    }
        });
    });
});
