function clearFormValidation(form) {
    $(form).validate().resetForm();

    // reset unobtrusive field level, if it exists
    $(form).find("[data-valmsg-replace]")
        .removeClass("field-validation-error")
        .addClass("field-validation-valid")
        .empty();
}
