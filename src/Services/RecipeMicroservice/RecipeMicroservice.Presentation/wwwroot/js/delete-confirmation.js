document.addEventListener('DOMContentLoaded', function () {
    // Attach to all delete buttons by class
    document.querySelectorAll('.btn-danger').forEach(function (btn) {
        btn.addEventListener('click', function (e) {
            if (!confirm('Are you sure you want to delete this item?')) {
                e.preventDefault();
            }
        });
    });
});