
function updateRecipeSelection(code) {
    const currentCodeEl = document.getElementById('currentRecipeCode');
    if (currentCodeEl) currentCodeEl.value = code;
    console.log('currentCodeEl:', currentCodeEl);
    console.log('code:', code);
    // Fetch partial HTML and replace the wrapper
    fetch('/Recipe/GetTheRecipe?code=' + encodeURIComponent(code), { method: 'GET' })
        .then(resp => {
            if (!resp.ok) throw new Error('Failed to load recipe partial');
            return resp.text();
        })
        .then(html => {
            const host = document.getElementById('recipeSection');
            if (host) host.innerHTML = html;

            // Close any open dropdown gracefully
            document.querySelectorAll('.dropdown.show .dropdown-btn')?.forEach(btn => {
                bootstrap.Dropdown.getOrCreateInstance(btn).hide();
            });
        })
        .catch(err => console.error('Error:', err));
}
function onIndexReady() {

    $('#btnCheckCode').on('click', function () {
        const code = $('#newRecipeCode').val().trim();
        if (!code) {
            $('#codeAvailability').text('Please enter a recipe code.');
            $('#btnProceedAdd').prop('disabled', true);
            return;
        }
        $.get('/Recipe/CheckCode', { code })
            .done(res => {
                $('#codeAvailability').text(res.message);
                $('#btnProceedAdd').prop('disabled', res.exists);
            })
            .fail(() => {
                $('#codeAvailability').text('Error checking code.');
                $('#btnProceedAdd').prop('disabled', true);
            });
    });

    $('#btnEdit').on('click', function () {
        const code = $('#currentRecipeCode').val();
        if (!code) { alert('Select a recipe code first.'); return; }
        window.location.href = `/Recipe/Edit?code=${encodeURIComponent(code)}`;
    });

    $('#btnRemove').on('click', function () {
        const code = $('#currentRecipeCode').val();
        if (!code) { alert('Select a recipe code first.'); return; }
        window.location.href = `/Recipe/RemoveRecipe?code=${encodeURIComponent(code)}`;
    });

    $('#btnPrint').on('click', function () {
        const code = $('#currentRecipeCode').val();
        if (!code) { alert('Select a recipe code first.'); return; }
        window.open(`/Recipe/Print?code=${encodeURIComponent(code)}`, '_blank');
    });

    $('#btnConfirmAdd').on('click', function () {
        const codeValue = $('#recipeName').val().trim();
        const $errorDiv = $('#duplicateError');
        const $inputField = $('#recipeName');

        if (!codeValue) {
            alert('Please enter a Recipe Name/Code.');
            return;
        }

        fetch(`/Recipe/CheckCode?code=${encodeURIComponent(codeValue)}`)
            .then(response => response.json())
            .then(data => {
                if (data.exists) {
                    $errorDiv.show();
                    $inputField.addClass('is-invalid');
                } else {
                    $errorDiv.hide();
                    $inputField.removeClass('is-invalid');
                    window.location.href = `/Recipe/AddRecipe?code=${encodeURIComponent(codeValue)}`;
                }
            })
            .catch(err => {
                console.error('Error:', err);
                alert('An error occurred while checking the recipe code.');
            });
    });

    $('#recipeName').on('input', function () {
        $('#duplicateError').hide();
        $(this).removeClass('is-invalid');
    });


}

$(function () { if ($('#currentRecipeCode').length) onIndexReady(); });
