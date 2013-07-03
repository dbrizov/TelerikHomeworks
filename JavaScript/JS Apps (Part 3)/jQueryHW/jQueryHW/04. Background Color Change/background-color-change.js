/// <reference path="../libs/jquery-1.10.1.js" />
/// <reference path="colorpicker.js" />
(function ($) {
    $('#color-picker').on('change', function () {
        $('body').css({
            'background-color':  $("#color-picker").val()
        });
    });
})(jQuery);