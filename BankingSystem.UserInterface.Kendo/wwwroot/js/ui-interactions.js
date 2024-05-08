function ShowNotification(message, type, style, timeout) {
    // STYLE: Bar, Flip Bar, Circle, ;
    // TYPE: Info, Success, Error etc
    var position = 'top';

    if (style == 'bar') {
        $('.page-content-wrapper').pgNotification({
            style: 'bar',
            message: message,
            position: position,
            timeout: timeout,
            type: type
        }).show();
    } else if (style == 'flip') {
        // Show a flipping notification animated
        // using CSS3 transforms and animations
        $('.page-content-wrapper').pgNotification({
            style: 'flip',
            message: message,
            position: position,
            timeout: timeout,
            type: type
        }).show();
    } else if (style == 'circle') {
        // Slide-in a circle notification from sides
        // You have to provide the HTML for thumbnail
        $('.page-content-wrapper').pgNotification({
            style: 'circle',
            title: 'John Doe',
            message: message,
            position: position,
            timeout: timeout,
            type: type,
            thumbnail: '<img width="40" height="40" style="display: inline-block;" src="/Content/assets/img/profiles/avatar2x.jpg" data-src="/Content/assets/img/profiles/avatar.jpg" data-src-retina="/Content/assets/img/profiles/avatar2x.jpg" alt="">'
        }).show();
    } else if (style == 'simple') {
        // Simple notification having bootstrap's .alert class
        $('.page-content-wrapper').pgNotification({
            style: 'simple',
            message: message,
            position: position,
            timeout: timeout,
            type: type
        }).show();
    } else {
        return;
    }
}

function ConfirmDialogue(head, msg) {
    var dialog = bootbox.dialog({
        title: head,
        message: "<p>" + msg + "</p>",
        buttons: {
            ok: {
                label: "OK",
                className: 'btn-info',
            }
        }
    });
}

function ShowAlertOkCancel(head, msg) {
    var dialog = bootbox.dialog({
        title: head,
        message: "<p>" + msg + "</p>",
        buttons: {
            cancel: {
                label: "Cancel",
                className: 'btn-danger',
                //    callback: function () {
                //        Example.show('Custom cancel clicked');
                //    }
            },
            ok: {
                label: "OK",
                className: 'btn-info',
                //    callback: function () {
                //        Example.show('Custom OK clicked');
                //    }
            }
        }
    });
}

function ShowAlertOkCancel(head, msg) {
    var dialog = bootbox.dialog({
        title: head,
        message: "<p>" + msg + "</p>",
        buttons: {
            cancel: {
                label: "Cancel",
                className: 'btn-danger',
                //    callback: function () {
                //        Example.show('Custom cancel clicked');
                //    }
            },
            noclose: {
                label: "Close",
                className: 'btn-warning',
                //    callback: function () {
                //        Example.show('Custom button clicked');
                //        return false;
                //    }
            },
            ok: {
                label: "OK",
                className: 'btn-info',
                //    callback: function () {
                //        Example.show('Custom OK clicked');
                //    }
            }
        }
    });
}

function GoTop() {
    $('html, body').animate({ scrollTop: 0 }, 'fast');
}

function ShowLoader(messageText) {
    if (messageText == '') {
        $('body').loadingModal('hide');
    }
    else {
        $('body').loadingModal({ text: messageText });
    }
    return false;
}

function hideParameters() {
    if ($("#quickview").hasClass("open")) {
        document.getElementById("open-parameters").click();
    }
}

function datetojson(date) {
    if (date == '') {
        var currentDate = new Date();
        var year = currentDate.getFullYear();
        var month = String(currentDate.getMonth() + 1).padStart(2, '0');
        var day = String(currentDate.getDate()).padStart(2, '0');
        date = day + '-' + month + '-' + year;
    }
    var dd = date.substr(0, 2);
    var mm = date.substr(3, 2);
    var yyyy = date.substr(6);
    var dtStr = yyyy + '-' + mm + '-' + dd + 'T00:00:00'; //"2023-09-21T00:00:00"
    return dtStr;
}

function setdatepicker(date) {
    var sdate = date.toLocaleString("en-UK");
    var dd = sdate.substr(0, 2);
    var mm = sdate.substr(3, 2);
    var yyyy = sdate.substr(6);
    var objdate = new Date(yyyy, mm, dd, 00, 00, 00);

    var datepicker = $("#jrn_date").data("kendoDatePicker");
    datepicker.value(objdate);
}

function convertToJSONDate(date) {
    var sdate = date.toLocaleString("en-UK");
    var dd = sdate.substr(0, 2);
    var mm = sdate.substr(3, 2);
    var yyyy = sdate.substr(6, 4);
    var objdate = new Date(yyyy, mm, dd, 00, 00, 00);
    objdate = '/Date(' + objdate.getTime() + ')/';
    return objdate;
}

function datestringuk(date) {
    var sdate = date.toLocaleString("en-UK");
    return sdate.replace(',', '');
}

function jsdatetoString(date) {
    var dt = new Date(parseInt(date.replace("/Date(", "").replace(")/", ""), 10));
    var dd = ("0" + dt.getDate()).slice(-2);
    var mm = ("0" + (parseInt(dt.getMonth()) + 1)).slice(-2);
    var yyyy = dt.getFullYear();
    var dts = yyyy + "-" + mm + "-" + dd;
    return dts;
}

function strDateToISO(strDate) {
    const inputDateString = "04/11/2023 11:38:49 AM";
    const inputDate = new Date(strDate);
    const targetDate = new Date("1900-01-01T00:00:00.000Z");
    const timeDifference = inputDate - targetDate;
    const resultDate = new Date(timeDifference);
    const isoDate = resultDate.toISOString();
    return isoDate;
}

function convertDatesToISO(jsonObj) {
    // Function to convert a single date string to ISO format
    function convertDateToISO(dateString) {
        const inputDate = new Date(dateString);
        return inputDate.toISOString();
    }

    // Recursive function to handle nested objects and arrays
    function processObject(obj) {
        for (var key in obj) {
            if (obj[key] instanceof Object) {
                processObject(obj[key]);
            } else if (typeof obj[key] === 'string' && obj[key].match(/^\d{2}\/\d{2}\/\d{4}/)) {
                obj[key] = convertDateToISO(obj[key]);
            }
        }
    }
    processObject(jsonObj);
    return jsonObj;
}

function generateSixDigitRandomNumber() {
    let randomNumber = Math.floor(Math.random() * 900000) + 100000;
    return randomNumber.toString();
}

function formatNumericString(numString) {
    let num = parseFloat(numString);
    if (isNaN(num)) {
        return "Invalid number";
    }
    let formattedNumber = num.toLocaleString('en-IN', {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2,
        style: 'decimal'
    });
    return formattedNumber;
}

(function ($) {

    'use strict';

    var getBaseURL = function () {
        var url = document.URL;
        return url.substr(0, url.lastIndexOf('/'));
    }

    $(document).ready(function () {
    });

})(window.jQuery);

function goTop() {
    $('html, body').animate({ scrollTop: 0 }, 'fast');
}

