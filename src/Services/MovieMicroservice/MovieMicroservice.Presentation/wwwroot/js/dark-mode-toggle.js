function setTheme(theme) {
    if (theme === 'auto') {
        document.documentElement.removeAttribute('data-bs-theme');
        localStorage.removeItem('theme');
    } else {
        document.documentElement.setAttribute('data-bs-theme', theme);
        localStorage.setItem('theme', theme);
    }
}

function toggleTheme() {
    const isDark = document.getElementById('themeToggle').checked;
    setTheme(isDark ? 'dark' : 'light');
    updateToggleLabel(isDark);
}

function updateToggleLabel(isDark) {
    const label = document.getElementById('themeToggleLabel');
    label.textContent = isDark ? 'Dark Mode' : 'Light Mode';
}

// On page load, apply saved theme and set toggle state
(function () {
    var savedTheme = localStorage.getItem('theme');
    var isDark = savedTheme === 'dark';
    if (savedTheme) {
        document.documentElement.setAttribute('data-bs-theme', savedTheme);
    }
    window.addEventListener('DOMContentLoaded', function () {
        var toggle = document.getElementById('themeToggle');
        if (toggle) {
            toggle.checked = isDark;
            updateToggleLabel(isDark);
        }
    });
})();