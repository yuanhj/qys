$().ready(function () {
    $('#btnJoin').on('click', function () {
        var template =
            '<div class="row demanitem" rel="0">' +
                        '<div class="control-group">' +
                            '<label class="control-label">受理单位：</label>' +
                            '<div class="controls"><select name="country"><option value="">请选择</option></select></div>' +
                            '<label class="control-label">受理部门：</label>' +
                            '<div class="controls"><select name="deperment"><option value="">请选择</option></select></div>' +
                            '<label class="control-label">受理人员：</label>' +
                            '<div class="controls"><select name="contanct"><option ori-data="">请选择</option></select> 联系电话：<span class="mobile"></span></div>' +
                            '<label class="control-label">受理时限：</label>' +
                            '<div class="controls"><input type="text" class="calendar" ori-data="" value="" name="calendar"/></div>' +
                        '</div>' +
                        '<div class="control-group">' +
                            '<label class="control-label">诉求需求：</label>' +
                            '<div class="controls"><textarea rows="5" cols="50" class="requirement" name="message" ori-data=""></textarea><input type="button" class="button btn-del" value="－删除"/></div>' +
                        '</div>' +
                    '</div>';
        $(template).insertBefore($(this));
        bindevent();
    });
    
    if ($('.row').length == 0) {
        $('#btnJoin').click();
    }
    
    bindevent();

    function bindevent() {
        $('select[name="country"]').each(function () {
            var _this = $(this);
            if (_this.data('init') != '1') {
                _this.data('init', '1');
                $.ajax({
                    type: 'get',
                    url: '../service/DemandHandler.ashx',
                    data: 'ac=country',
                    success: function (data) {
                        var json = eval("(" + data + ")");
                        _this.empty().append('<option value="">请选择</option>').append(optionitem(json));
                    },
                    error: function () {
                        alert('sdfsd');
                    }
                });
                $(_this).on('change', function () {
                    //empty depanent contanct
                    var deperment = _this.parents('div.row').find('select[name="deperment"]');
                    deperment.empty().append('<option value="">请选择</option>');
                    var value = _this.val();
                    if (value) {
                        $.ajax({
                            type: 'get',
                            url: '../service/DemandHandler.ashx',
                            data: 'ac=deperment&cid=' + value,
                            success: function (data) {
                                var json = eval("(" + data + ")");
                                deperment.append(optionitem(json));
                            },
                            error:function () {
                                alert('12312');
                            }
                        });
                    }
                });
            }
            //del
            $('.btn-del').on('click', function () {
                var div = $(this).parents('div.row');
                div.data('del', '1');
                div.find('select[name="contanct"]').val('');
                div.find('textarea[name="message"]').val('');
                div.find('input[name="calendar"]').val('');
                div.hide();
            });
        });

        $('select[name="deperment"]').each(function () {
            var _this = $(this);
            if (_this.data('init') != '1') {
                _this.data('init', '1');
                _this.on('change', function () {
                    var contanct = _this.parents('div.row').find('select[name="contanct"]');
                    contanct.empty().append('<option value="">请选择</option>');
                    var value = _this.val();
                    if (value) {
                        $.ajax({
                            type: 'get',
                            url: '../service/DemandHandler.ashx',
                            data: 'ac=contact&did=' + value,
                            success: function (data) {
                                var json = eval("(" + data + ")");
                                contanct.append(optionitem(json));
                                contanct.data('jsondata', json);
                            }
                        });
                    }
                });
            }
        });
        
        function optionitem(json) {
            var options = '';
            for (var i in json) {
                options +='<option value="' + json[i]["id"] + '">' + json[i]["name"] + '</option>';
            }
            return options;
        }

        //initinfo
        $('select[name="contanct"]').each(function () {
            var _this = $(this);
            if (_this.data('init') != '1') {
                _this.data('init', '1');
                var oridata = _this.attr('ori-data');
                if (oridata) {
                    var contanct = _this.parents('div.row').find('select[name="contanct"]');
                    var deperment = _this.parents('div.row').find('select[name="deperment"]');
                    var county = _this.parents('div.row').find('select[name="country"]');
                    $.ajax({
                        type: 'get',
                        url: '../service/DemandHandler.ashx',
                        data: 'ac=contactinfo&pid=' + oridata,
                        success: function (data) {
                            var json = eval("(" + data + ")");
                            contanct.empty().append('<option value="">请选择</option>');
                            contanct.append(optionitem(json.contactdata)).val(oridata);
                            deperment.empty().append('<option value="">请选择</option>');
                            deperment.append(optionitem(json.departmentdata)).val(json.department);
                            contanct.data('jsondata', json.contactdata);
                            if (json.county) {
                                county.val(json.county);
                            }
                        },
                        error:function () {
                            alert('err');
                        }
                    });
                }
                $(_this).on('change', function () {
                    var select = $(this);
                    var json = select.data('jsondata');
                    var mobile = select.next('span.mobile');
                    var value = select.val();
                    if (value) {
                        for (var item in json) {
                            if (json[item]['id'] == value) {
                                mobile.html(json[item]['mobile']);
                                return;
                            }
                        }
                    } else {
                        mobile.html('');
                    }
                });
            }
        });
        BUI.use('bui/calendar', function (Calendar) {
            var datepicker = new Calendar.DatePicker({
                trigger: '.calendar',
                dateMask: 'yyyy-mm-dd',
                autoRender: true
            });
        });
    }

    //form click
    $('#But_Save').on('click', function () {
        var hfdata = $('#hfData');
        hfdata.val('');
        var have = false;
        $('.row').each(function () {
            var _this = $(this);
            var contact = _this.find('select[name="contanct"]');
            var message = _this.find('textarea[name="message"]');
            var expirdata = _this.find('input[name="calendar"]');
            if (_this.attr('rel') == '0' || contact.attr('ori-data') != contact.val() || message.attr('ori-data') != message.val() || expirdata.attr('ori-data') != expirdata.val()) {
                hfdata.val(hfdata.val() + '#' + _this.attr('rel') + '|' + contact.val() + '|' + message.val() + '|' + expirdata.val());
                if (!have && !_this.data('del')) {
                    have = true;
                }
            }
        });
        if (!have) {
            alert('请至少填写一家受理单位');
            return false;
        }
    });
});