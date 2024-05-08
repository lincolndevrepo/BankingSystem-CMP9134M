$(document).on('click', "#menu-manage-bank-account", function (e) {
    e.preventDefault();
    window.location = "/accounts/index/";
});

$(document).on('click', "#menu-transactions-deposit", function (e) {
    e.preventDefault();
    window.location = "/transactions/deposit/";
});

$(document).on('click', "#menu-transactions-withdraw", function (e) {
    e.preventDefault();
    window.location  = "/transactions/withdraw/";
});

$(document).on('click', "#menu-transactions-transfer", function (e) {
    e.preventDefault();
    window.location = "/transactions/transfer/";
});

$(document).on('click', "#menu-transactions-history", function (e) {
    e.preventDefault();
    window.location = "/transactions/history/";
});

$(document).on('click', "#menu-services-account-info", function (e) {
    e.preventDefault();
    window.location = "/services/accountinformation/";
});

$(document).on('click', "#menu-services-cashbook-cards-request", function (e) {
    e.preventDefault();
    window.location = "/services/checkbookandcards/";
});

$(document).on('click', "#menu-services-recurring-payments", function (e) {
    e.preventDefault();
    window.location = "/services/recurringpayments/";
});