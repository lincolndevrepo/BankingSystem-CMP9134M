(function ($) {
    $.fn.numericValue = function (newValue) {
        if (newValue === undefined) {
            return this.data("kendoNumericTextBox").value();
        }

        return this.each(function () {
            var kendoWidget = $(this).data("kendoNumericTextBox");
            if (kendoWidget) {
                kendoWidget.value(newValue);
            }
        });
    };
})(jQuery);



(function ($) {
    $.fn.textBoxValue = function (newValue) {
        if (newValue === undefined) {
            return this.data("kendoTextBox").value();
        }

        return this.each(function () {
            var kendoWidget = $(this).data("kendoTextBox");
            if (kendoWidget) {
                kendoWidget.value(newValue);
            }
        });
    };
})(jQuery);


(function ($) {
    $.fn.dateInputValue = function (newDate) {
        if (newDate === undefined) {
            return this.data("kendoDateInput").value();
        }

        return this.each(function () {
            var kendoWidget = $(this).data("kendoDateInput");
            if (kendoWidget) {
                kendoWidget.value(newDate);
            }
        });
    };
})(jQuery);

(function ($) {
    $.fn.dateToUk = function () {
        return this.each(function () {
            var dateString = $(this).text();
            var date = new Date(dateString);
            if (!isNaN(date.getTime())) {
                var day = String(date.getDate()).padStart(2, '0');
                var month = String(date.getMonth() + 1).padStart(2, '0');
                var year = date.getFullYear();
                var ukDate = day + '/' + month + '/' + year;
                $(this).text(ukDate);
            }
        });
    };
})(jQuery);

(function ($) {
    $.fn.checked = function (isChecked) {
        return this.each(function () {
            $(this).prop("checked", isChecked);
        });
    };
})(jQuery);

function dateToUk(jsonDate) {
    var date = new Date(jsonDate);
    if (!isNaN(date.getTime())) {
        var day = String(date.getDate()).padStart(2, '0');
        var month = String(date.getMonth() + 1).padStart(2, '0');
        var year = date.getFullYear();
        return day + '/' + month + '/' + year;
    }
    return '01/01/1901';
}