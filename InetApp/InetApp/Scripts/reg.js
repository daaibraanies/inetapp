
$("form span").hide();

var username = $("#username");
var password = $("#password");
var confirm = $("#con_password");

function is_name() {
    return username.val().length > 4;
}

function is_match() {
    return password.val() === confirm.val();
}
function is_valid() {
    return password.val().length > 8;
}

function is_submit() {
    return is_valid() && is_match() && is_name();
}
function checkName() {
    if (is_name()) {
        username.next().hide();
    } else {
        username.next().show();
    }
    enable();
}

function checkEvent() {
    if (is_valid()) {
        password.next().hide();
    } else {
        password.next().show();
    }
    enable();
}

function matchEvent() {
    if (is_match()) {
        confirm.next().hide();
    } else {
        confirm.next().show();
    }
    enable();
}

function hidden() {
    $("form span").hide();
}

function enable() {
    $("#submit").prop("disabled", !is_submit());
}

username.focus(checkName).keyup(checkName);
password.focus(checkEvent).keyup(checkEvent).keyup(matchEvent);
confirm.focus(matchEvent).keyup(matchEvent).keyup(checkEvent);
username.focusout(hidden);
password.focusout(hidden);
confirm.focusout(hidden);



enable();





