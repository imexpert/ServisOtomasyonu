"use strict";

// Class Definition
var KTAnaSayfa = function () {
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

var KTAramaDatatable = function () {
    // Private functions

    // basic demo
    var getData = function () {

        var options = {
            // datasource definition
            data: {
                type: 'remote',
                source: {
                    read: {
                        url: HOST_URL + '/arama/Ara',
                        type: 'POST',
                        beforeSend: function (req) {
                            req.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("token"));
                        },
                        // sample custom headers
                        // headers: {'x-my-custom-header': 'some value', 'x-test-header': 'the value'},
                        map: function (raw) {
                            // sample data mapping
                            var dataSet = raw;
                            if (typeof raw.data !== 'undefined') {
                                dataSet = raw.data;
                            }
                            return dataSet;
                        },
                    },
                },
                pageSize: 10,
                serverPaging: true,
                serverFiltering: true,
                serverSorting: true,
            },

            // layout definition
            layout: {
                scroll: true, // enable/disable datatable scroll both horizontal and vertical when needed.
                height: 550, // datatable's body's fixed height
                footer: false, // display/hide footer
            },

            // column sorting
            sortable: true,

            pagination: true,

            search: {
                input: $('#kt_datatable_search_query'),
                key: 'generalSearch'
            },

            // columns definition
            columns: [
                {
                    field: 'Unvan',
                    title: 'Unvan',
                    sortable: false,
                    type: 'text',
                    width: 30,
                    selector: true,
                    textAlign: 'center',
                    template: function (row) {
                        return row.RecordID;
                    },
                },
                //{
                //	field: 'RecordID',
                //	title: 'ID',
                //	width: 30,
                //	type: 'number',
                //}, {
                //	field: 'OrderID',
                //	title: 'Order ID',
                //}, {
                //	field: 'Country',
                //	title: 'Country',
                //	template: function (row) {
                //		return row.Country + ' ' + row.ShipCountry;
                //	},
                //}, {
                //	field: 'ShipDate',
                //	title: 'Ship Date',
                //	type: 'date',
                //	format: 'MM/DD/YYYY',
                //}, {
                //	field: 'CompanyName',
                //	title: 'Company Name',
                //}, {
                //	field: 'Status',
                //	title: 'Status',
                //	// callback function support for column rendering
                //	template: function (row) {
                //		var status = {
                //			1: { 'title': 'Pending', 'class': 'label-light-primary' },
                //			2: { 'title': 'Delivered', 'class': ' label-light-danger' },
                //			3: { 'title': 'Canceled', 'class': ' label-light-primary' },
                //			4: { 'title': 'Success', 'class': ' label-light-success' },
                //			5: { 'title': 'Info', 'class': ' label-light-info' },
                //			6: { 'title': 'Danger', 'class': ' label-light-danger' },
                //			7: { 'title': 'Warning', 'class': ' label-light-warning' },
                //		};
                //		return '<span class="label ' + status[row.Status].class + ' label-inline font-weight-bold label-lg">' + status[row.Status].title + '</span>';
                //	},
                //}, {
                //	field: 'Type',
                //	title: 'Type',
                //	autoHide: false,
                //	// callback function support for column rendering
                //	template: function (row) {
                //		var status = {
                //			1: { 'title': 'Online', 'state': 'danger' },
                //			2: { 'title': 'Retail', 'state': 'primary' },
                //			3: { 'title': 'Direct', 'state': 'success' },
                //		};
                //		return '<span class="label label-' + status[row.Type].state + ' label-dot mr-2"></span><span class="font-weight-bold text-' + status[row.Type].state + '">' +
                //			status[row.Type].title + '</span>';
                //	},
                //}, {
                //	field: 'Actions',
                //	title: 'Actions',
                //	sortable: false,
                //	width: 125,
                //	overflow: 'visible',
                //	autoHide: false,
                //	template: function () {
                //		return '\
                //			<div class="dropdown dropdown-inline">\
                //				<a href="javascript:;" class="btn btn-sm btn-clean btn-icon" data-toggle="dropdown">\
                //                             <i class="la la-cog"></i>\
                //                         </a>\
                //			  	<div class="dropdown-menu dropdown-menu-sm dropdown-menu-right">\
                //					<ul class="nav nav-hoverable flex-column">\
                //			    		<li class="nav-item"><a class="nav-link" href="#"><i class="nav-icon la la-edit"></i><span class="nav-text">Edit Details</span></a></li>\
                //			    		<li class="nav-item"><a class="nav-link" href="#"><i class="nav-icon la la-leaf"></i><span class="nav-text">Update Status</span></a></li>\
                //			    		<li class="nav-item"><a class="nav-link" href="#"><i class="nav-icon la la-print"></i><span class="nav-text">Print</span></a></li>\
                //					</ul>\
                //			  	</div>\
                //			</div>\
                //			<a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Edit details">\
                //				<i class="la la-edit"></i>\
                //			</a>\
                //			<a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Delete">\
                //				<i class="la la-trash"></i>\
                //			</a>\
                //		';
                //	},
                //}
            ],

        };

        var datatable = $('#kt_datatable').KTDatatable(options);

        // both methods are supported
        // datatable.methodName(args); or $(datatable).KTDatatable(methodName, args);

        $('#kt_datatable_destroy').on('click', function () {
            // datatable.destroy();
            $('#kt_datatable').KTDatatable('destroy');
        });

        $('#kt_datatable_init').on('click', function () {
            datatable = $('#kt_datatable').KTDatatable(options);
        });

        $('#kt_datatable_reload').on('click', function () {
            // datatable.reload();
            $('#kt_datatable').KTDatatable('reload');
        });

        $('#kt_datatable_sort_asc').on('click', function () {
            datatable.sort('Status', 'asc');
        });

        $('#kt_datatable_sort_desc').on('click', function () {
            datatable.sort('Status', 'desc');
        });

        // get checked record and get value by column name
        $('#kt_datatable_get').on('click', function () {
            // select active rows
            datatable.rows('.datatable-row-active');
            // check selected nodes
            if (datatable.nodes().length > 0) {
                // get column by field name and get the column nodes
                var value = datatable.columns('CompanyName').nodes().text();
                console.log(value);
            }
        });

        // record selection
        $('#kt_datatable_check').on('click', function () {
            var input = $('#kt_datatable_check_input').val();
            datatable.setActive(input);
        });

        $('#kt_datatable_check_all').on('click', function () {
            // datatable.setActiveAll(true);
            $('#kt_datatable').KTDatatable('setActiveAll', true);
        });

        $('#kt_datatable_uncheck_all').on('click', function () {
            // datatable.setActiveAll(false);
            $('#kt_datatable').KTDatatable('setActiveAll', false);
        });

        $('#kt_datatable_hide_column').on('click', function () {
            datatable.columns('ShipDate').visible(false);
        });

        $('#kt_datatable_show_column').on('click', function () {
            datatable.columns('ShipDate').visible(true);
        });

        $('#kt_datatable_remove_row').on('click', function () {
            datatable.rows('.datatable-row-active').remove();
        });

        $('#kt_datatable_search_status').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'Status');
        });

        $('#kt_datatable_search_type').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'Type');
        });

        $('#kt_datatable_search_status, #kt_datatable_search_type').selectpicker();

    };

    return {
        // public functions
        init: function () {
            getData();
        },
    };
}();

// Class Initialization
jQuery(document).ready(function () {
    $('#Unvan').on('keypress', function (e) {
        if (e.which === 13) {
            $("#AramaKriter").val($("#Unvan").val());
            $("#AramaKriter").focus();

            KTAramaDatatable.init();

            showModal("modalArama");
        }
    });
});