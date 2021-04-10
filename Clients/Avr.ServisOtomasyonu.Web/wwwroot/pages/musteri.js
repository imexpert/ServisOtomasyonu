"use strict";

// Class Definition
var KTMusteri = function () {
    var _musteri;

    var _showForm = function (form) {
        var cls = 'login-' + form + '-on';
        var form = 'kt_musteri_' + form + '_form';

        _musteri.removeClass('login-forgot-on');
        _musteri.removeClass('login-signin-on');
        _musteri.removeClass('login-signup-on');

        _musteri.addClass(cls);

        KTUtil.animateClass(KTUtil.getById(form), 'animate__animated animate__backInUp');
    }

    var _handleMusteriForm = function () {
        var validation;
        var formSubmitButton = KTUtil.getById('btnMusteriKaydet');

        validation = FormValidation.formValidation(
            KTUtil.getById('avr_musteri_form'),
            {
                fields: {
                    MusteriUnvan: {
                        validators: {
                            notEmpty: {
                                message: 'Unvan zorunludur.'
                            }
                        }
                    },
                    SektorKodu: {
                        validators: {
                            digits: {
                                message: 'Sektör kodu zorunludur.'
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    submitButton: new FormValidation.plugins.SubmitButton(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        );

        $('#btnMusteriKaydet').on('click', function (e) {
            e.preventDefault();

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    PostForm("musteri/musterikaydet", "avr_musteri_form").done(function (response) {
                        if (response.isSuccess) {
                            localStorage.setItem("token", response.data.token);
                            ShowSuccessMessage("Başarılı", "Müşteri kaydı başarıyla oluşturuldu.");
                        }
                        else {
                            ShowErrorMessage("Hata", response.message);
                        }
                    });
                }
            });
        });

        // Handle forgot button
        $('#kt_musteri_forgot').on('click', function (e) {
            e.preventDefault();
            _showForm('forgot');
        });

        // Handle signup
        $('#kt_musteri_signup').on('click', function (e) {
            e.preventDefault();
            _showForm('signup');
        });
    }

    var _handleMusteriAdresForm = function () {
        var validation;

        validation = FormValidation.formValidation(
            KTUtil.getById('avr_musteri_adres_form'),
            {
                fields: {
                    SehirId: {
                        validators: {
                            digits: {
                                message: 'Şehir seçmediniz.'
                            }
                        }
                    },
                    IlceId: {
                        validators: {
                            digits: {
                                message: 'İlçe seçmediniz.'
                            }
                        }
                    },
                    AcikAdres: {
                        validators: {
                            notEmpty: {
                                message: 'Açık Adres girmediniz.'
                            }
                        }
                    },
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    submitButton: new FormValidation.plugins.SubmitButton(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        );

        $('#btnMusteriAdresKaydet').on('click', function (e) {
            e.preventDefault();

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    PostForm("musteriadres/musteriadreskaydet", "avr_musteri_adres_form").done(function (response) {
                        if (response.isSuccess) {
                            ShowSuccessMessage("Başarılı", "Adres kaydı başarıyla oluşturuldu.");
                        }
                        else {
                            ShowErrorMessage("Hata", response.message);
                        }
                    });
                }
            });
        });
    }

    // Public Functions
    return {
        // public functions
        init: function () {
            _musteri = $('#kt_musteri');

            _handleMusteriForm();
            _handleMusteriAdresForm();
        }
    };
}();

// Class Initialization
jQuery(document).ready(function () {
    KTMusteri.init();
});