$(function () {
    $('#productFormSubmit').click(function (event) {
        if (confirm('Are you sure?')==false) {
            event.preventDefault();
        }
    });
});