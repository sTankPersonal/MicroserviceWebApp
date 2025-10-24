function initializeAjaxList(config) {
    const { formId, containerId, partialUrl, listId } = config;
    const form = document.getElementById(formId);
    const container = document.getElementById(containerId);

    if (!form || !container) {
        console.error("Missing required elements for Ajax list initialization");
        return;
    }

    // Helper: Load data from server and update container
    async function loadData(params = "") {
        try {
            const response = await fetch(`${partialUrl}?${params}`, {
                headers: { 'X-Requested-With': 'XMLHttpRequest' }
            });

            if (!response.ok) throw new Error(`HTTP ${response.status}`);

            container.innerHTML = await response.text();
        } catch (err) {
            console.error("❌ Failed to load data:", err);
        }
    }

    // Handle form submit (search/filter)
    form.addEventListener("submit", e => {
        e.preventDefault();
        const params = new URLSearchParams(new FormData(form)).toString();
        loadData(params);
    });

    // Handle pagination buttons (delegated)
    document.addEventListener("click", e => {
        const btn = e.target.closest(".page-btn");
        if (!btn) return;

        e.preventDefault();

        const formData = new FormData(form);
        formData.set("pageNumber", btn.dataset.page);
        const params = new URLSearchParams(formData).toString();
        loadData(params);
    });

    // Handle reset button
    const resetBtn = document.getElementById(`${listId}ResetBtn`);
    if (resetBtn) {
        resetBtn.addEventListener("click", () => {
            form.reset();
            form.querySelectorAll('input[type="text"]').forEach(input => input.value = "");
            initializeSelect2(form, true);
            loadData();
        });
    }

    // Initialize select2 fields
    initializeSelect2(form);
}

function initializeSelect2(scope = document, reset = false) {
    if (typeof $ === "undefined" || !$.fn.select2) {
        console.error("jQuery or Select2 not loaded");
        return;
    }

    const $fields = $(scope).find(".select2-field");
    console.log(`Initializing Select2 for ${$fields.length} fields`, reset ? "(reset mode)" : "");

    $fields.each(function () {
        const $el = $(this);

        // Re-init handling
        if (reset && $el.data("select2")) $el.select2("destroy");
        if ($el.data("select2")) return;

        const ajaxUrl = $el.data("ajax-url");
        const textField = $el.data("ajax-text-field") || "text";
        const idField = $el.data("ajax-id-field") || "id";

        const select2Config = {
            width: "100%",
            placeholder: $el.data("placeholder") || "",
            allowClear: true,
            minimumInputLength: 0,
            dropdownParent: $el.parent()
        };

        if (ajaxUrl) {
            select2Config.ajax = {
                url: ajaxUrl,
                dataType: "json",
                delay: 250,
                data: params => ({
                    searchName: params.term || "",
                    pageNumber: params.page || 1,
                    pageSize: 10
                }),
                processResults: (data, params) => {
                    const page = params.page || 1;
                    const items = data.items || data.Items || [];
                    const total = data.totalItems || data.TotalItems || 0;

                    return {
                        results: items.map(item => ({
                            id: item[idField],
                            text: item[textField]
                        })),
                        pagination: {
                            more: page * 10 < total
                        }
                    };
                },
                cache: true
            };
        }

        $el.select2(select2Config);

        // Ensure focus on open
        $el.on("select2:open", () => {
            setTimeout(() => {
                document.querySelector(".select2-search__field")?.focus();
            }, 0);
        });
    });
}
