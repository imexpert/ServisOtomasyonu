

var url;

function PostForm(methodName, formName) {
    url = methodName;
    return $.ajax({
        url: url,
        type: "POST",
        data: $("#" + formName).serialize(),
        beforeSend: function (xhr) {
            if (localStorage.getItem("token") != undefined) {
                xhr.setRequestHeader('Authorization', "Bearer " + localStorage.getItem("token"));
            }
        },
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        cache: false,
        error: handleError,
    });
}

function Post(methodName, data) {
    url = HOST_URL + methodName;
    return $.ajax({
        url: url,
        type: "POST",
        data: data,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', "Bearer " + localStorage.getItem("token"));
        },
        dataType: 'json',
        contentType: "application/json",
        cache: false,
        error: handleError,
    });
}

function Get(Url, Data) {
    url = Url;
    return $.ajax({
        url: Url,
        type: "GET",
        data: Data,
        beforeSend: function (xhr) {
            if (localStorage.getItem("token") != undefined) {
                xhr.setRequestHeader('Authorization', "Bearer " + localStorage.getItem("token"));
            }
        },
        dataType: 'json',
        contentType: "application/json",
        cache: false,
        error: handleError,
    });

}
function handleError(err) {
    if (err.status == 404) {
        ShowErrorMessage("Method bulunamadı - " + url);
    }
    else {
        ShowErrorMessage(err.statusText + " - " + url);
    }
}

function ShowSuccessMessage(title, message) {
    swal.fire({
        title: title,
        html: message,
        icon: "success",
        allowOutsideClick: false,
        allowEscapeKey: true,
        buttonsStyling: false,
        confirmButtonText: "Tamam",
        customClass: {
            confirmButton: "btn font-weight-bold btn-light-primary"
        }
    }).then(function () {

        KTUtil.scrollTop();
    });
}

function ShowErrorMessage(title, message) {
    swal.fire({
        title: title,
        html: message,
        icon: "error",
        allowOutsideClick: false,
        allowEscapeKey: false,
        buttonsStyling: false,
        confirmButtonText: "Tamam",
        customClass: {
            confirmButton: "btn font-weight-bold btn-light-primary"
        }
    }).then(function () {

        KTUtil.scrollTop();
    });
}


function showModal(name) {
    $('#' + name).modal('show');
}
$(document).ready(function () {
    $(document).ajaxStart(function () {
        KTApp.blockPage({
            overlayColor: '#C62828',
            state: 'danger',
            message: 'Lütfen bekleyiniz...'
        });
    });
    $(document).ajaxComplete(function () {
        KTApp.unblockPage();
    });
});