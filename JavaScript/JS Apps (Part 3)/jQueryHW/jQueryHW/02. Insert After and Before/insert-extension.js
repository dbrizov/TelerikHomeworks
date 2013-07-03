/// <reference path="../libs/jquery-1.10.1.js" />
(function ($) {
    $('#add-after').on('click', function (ev) {
        $('.blue').after('<div class="green"></div>');
    });

    $('#add-before').on('click', function (ev) {
        $('.blue').before('<div class="green"></div>');
    });
})(jQuery);