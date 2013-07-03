/// <reference path="jquery-1.10.1.js" />
(function ($) {
    $.fn.treeview = function () {
        var element = this;
        element.find('ul')
               .css("display", "none");

        element.find('li')
			   .css('cursor', 'pointer')
               .on('click', function (ev) {
                   ev.stopPropagation();

                   var ulChildren = $(this).children('ul');
                   if (ulChildren.css('display') === "none") {
                       ulChildren.css('display', 'block');
                   }
                   else {
                       ulChildren.css('display', 'none');
                   }
               });
    }
})(jQuery);