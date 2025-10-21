function initializeAjaxList(config) {
    const form = document.getElementById(config.formId);
    const container = document.getElementById(config.containerId);

    async function loadData(params) {
        const response = await fetch(`${config.partialUrl}?${params}`, {
            headers: { 'X-Requested-With': 'XMLHttpRequest' }
        });
        const html = await response.text();
        container.innerHTML = html;
        //initializeSelect2(container);
    }

    form.addEventListener("submit", function (e) {
        e.preventDefault();
        const params = new URLSearchParams(new FormData(this)).toString();
        loadData(params);
    });

    document.addEventListener("click", function (e) {
        if (e.target.classList.contains("page-btn")) {
            e.preventDefault();
            const page = e.target.dataset.page;
            const formData = new FormData(form);
            formData.append("pageNumber", page);
            const params = new URLSearchParams(formData).toString();
            loadData(params);
        }
    });

    const resetBtn = document.getElementById(`${config.listId}ResetBtn`);
    if (resetBtn) {
        resetBtn.addEventListener("click", () => {
            form.reset();
            form.querySelectorAll('input[type="text"]').forEach(input => input.value = "");
            initializeSelect2(form, true);
            loadData("");
        });
    }

    // Initialize Select2 for the first render
    initializeSelect2(document);
}

function initializeSelect2(scope = document, reset = false) {
    if (typeof $ === "undefined" || !$.fn.select2) {
        console.error("❌ jQuery or Select2 not loaded");
        return;
    }

    const $fields = $(scope).find(".select2-field");
    console.log("Initializing Select2 for", $fields.length, "fields");

    $(scope).find(".select2-field").each(function () {
        const $el = $(this);

        // If reset requested or already initialized, cleanly destroy
        if (reset && $el.data("select2")) {
            $el.select2("destroy");
        }

        // Skip if already initialized
        if ($el.data("select2")) return;

        const ajaxUrl = $el.data("ajax-url");
        const textField = $el.data("ajax-text-field") || "text";
        const idField = $el.data("ajax-id-field") || "id";

        const config = {
            width: "100%",
            placeholder: $el.data("placeholder") || "",
            allowClear: true,
            minimumInputLength: 0, // allows clicking without typing first
            dropdownParent: $el.parent() // prevents hidden focus issue
        };

        if (ajaxUrl) {
            config.ajax = {
                url: ajaxUrl,
                dataType: "json",
                delay: 250,
                data: function (params) {
                    return {
                        searchName: params.term || "",
                        pageNumber: params.page || 1,
                        pageSize: 10
                    };
                },
                processResults: function (data, params) {
                    params.page = params.page || 1;
                    const items = data.items || data.Items || [];
                    const total = data.totalItems || data.TotalItems || 0;

                    return {
                        results: items.map(item => ({
                            id: item[idField],
                            text: item[textField]
                        })),
                        pagination: {
                            more: (params.page * 10) < total
                        }
                    };
                },
                cache: true
            };
        }

        $el.select2(config);

        // 🔥 Force focus into the search box when dropdown opens
        $el.on("select2:open", function () {
            setTimeout(() => {
                document.querySelector(".select2-search__field")?.focus();
            }, 0);
        });
    });
}
