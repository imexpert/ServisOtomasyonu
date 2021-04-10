var select2g_noDataFound = "Hiçbir kayıt bulunamadı";
var select2g_maximumSelected = "En fazla args.maximum seçim yapabilirsiniz"; // args.maximum is a variable, which select2generator will replace it a number with maximumSelectedText
var select2g_minimumInputLength = 3; // you can set a default value for minimumInputLength here
var select2g_maximumInputLength = 0; // 0 is infinite
var select2g_inputTooShortText = "Lütfen args.minimum ve üzeri karakter girin"; // args.minimum is a variable, which select2generator will replace it a number with inputTooShortText. Also args.input is the user-typed text
var select2g_inputTooLongText = "En fazla args.maximum karakter girebilirsiniz"; // args.maximum is a variable, which select2generator will replace it a number with inputTooLongText. Also args.input is the user-typed text

function select2GeneratorTryCatchFunc(thisFromReady) {
    try {
        var thisSelect = $(thisFromReady);

        if ($(thisSelect).attr("data-maximumSelectedText") == "" || $(thisSelect).attr("data-maximumSelectedText") == undefined) { $(thisSelect).attr("data-maximumSelectedText", select2g_maximumSelected); }
        if ($(thisSelect).attr("data-inputTooShortText") == "" || $(thisSelect).attr("data-inputTooShortText") == undefined) { $(thisSelect).attr("data-inputTooShortText", select2g_inputTooShortText); }
        if ($(thisSelect).attr("data-inputTooLongText") == "" || $(thisSelect).attr("data-inputTooLongText") == undefined) { $(thisSelect).attr("data-inputTooLongText", select2g_inputTooLongText); }

        $(thisSelect).select2({
            dropdownParent: $(thisSelect).attr("data-dropdownParent") != undefined ? $(thisSelect).attr("data-dropdownParent") : "",
            "language": $(thisSelect).attr("data-language") != undefined ? $(thisSelect).attr("data-language") : "",
            "placeholder": $(thisSelect).attr("data-placeholder") != undefined ? $(thisSelect).attr("data-placeholder") : "",
            "language": {
                "noResults": function () {
                    return $(thisSelect).attr("data-noDataFound") == undefined ? select2g_noDataFound : $(thisSelect).attr("data-noDataFound");
                },
                "maximumSelected": function (e) {
                    return $(thisSelect).attr("data-maximumSelectedText").replace("args.maximum", e.maximum);
                }
            },
            "allowClear": ($(thisSelect).attr("data-allowClear") == undefined || $(thisSelect).attr("data-allowClear") == "") ? false : true, // null or undefined => false, else anything is true! ex: a is true, asdasd is true, too!
            "maximumSelectionLength": ($(thisSelect).attr("data-maximumSelectionLength") == undefined || $(thisSelect).attr("data-maximumSelectionLength") == "0" || isNaN($(thisSelect).attr("data-maximumSelectionLength")) == true || $(thisSelect).attr("data-maximumSelectionLength") == "") ? 0 : $(thisSelect).attr("data-maximumSelectionLength")
        });
    }
    catch (err) {
        console.log(`An error occured: ${err}`);
    }
}

function generateParametreSelect(thisFromReady) {

    var dataUrl = $(thisFromReady).attr("data-url");
    var dataText = $(thisFromReady).attr("data-text");
    var dataValue = $(thisFromReady).attr("data-value");
    var anaGrupKod = $(thisFromReady).attr("data-anaGrupKod");
    var grupKod = $(thisFromReady).attr("data-parametreGrup");

    $(thisFromReady).on('change', function () {
        if (thisFromReady.value == null || thisFromReady.value == undefined || thisFromReady.value == "") {
            $("#"+thisFromReady.name).val("Seçiniz").trigger('change');
            return;
        }
    });

    if ($(thisFromReady).attr("data-defaultOptionText") != undefined) {
        $(thisFromReady).append(`<option value="${$(thisFromReady).attr("data-defaultOptionValue") != undefined ? $(thisFromReady).attr("data-defaultOptionValue") : $(thisFromReady).attr("data-defaultOptionText")}" disabled="disabled" selected="selected">${$(thisFromReady).attr("data-defaultOptionText")}</option>`);
    }

    if (dataUrl != undefined && dataUrl != "") {

        KTApp.blockPage({
            overlayColor: '#C62828',
            state: 'danger',
            message: 'Lütfen bekleyiniz...'
        });

        var data = {
            "anaGrupKod": anaGrupKod,
            "grupKod": grupKod
        }

        Get(dataUrl, data)
            .done(function (response) {
            if (response.isSuccess) {
                $.each(response.data, function (i, item) {
                    if ((dataText != "" && dataText != undefined) && (dataValue != "" && dataValue != undefined)) {
                        $(thisFromReady).append(new Option(item[dataText], item[dataValue]));
                    } 
                    else if (Object.keys(item).length > 1) {
                        $(thisFromReady).append(new Option(item[Object.keys(item)[1]], item[Object.keys(item)[0]]));
                    } 
                });

                select2GeneratorTryCatchFunc(thisFromReady);

                KTApp.unblockPage();
            }
            else {
                ShowErrorMessage("Hata", result.message);
            }
        });
    }
}

function clearAndInitialize(name, isEmpty) {
    var childName = "";
    if (!name.includes("#")) {
        childName = "#" + name;
    }
    else {
        childName = name;
    }

    if (isEmpty) {
        $(childName).empty();
    }

    $(childName).append(`<option value="${$(childName).attr("data-defaultOptionValue") != undefined ? $(childName).attr("data-defaultOptionValue") : $(childName).attr("data-defaultOptionText")}" disabled="disabled" selected="selected">${$(childName).attr("data-defaultOptionText")}</option>`);

    if ($(childName).attr("data-childName") != "" && $(childName).attr("data-childName") != undefined) {
        clearAndInitialize($(childName).attr("data-childName"), true);
    }
}

$(document).ready(function () {
    $(".select2Parametre").each(function (i, item) {
        generateParametreSelect(this);
    });
});



