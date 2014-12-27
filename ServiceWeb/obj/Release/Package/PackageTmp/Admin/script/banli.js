$().ready(function () {
    function revalue() {
        var havemessage = false;
        var hfdata = $('#hfData');
        hfdata.val('');
        $('.banliitem').each(function () {
            var _this = $(this);
            var message = _this.find('textarea[name="message"]');
            var raty = _this.find('.raty');
            if (!havemessage && message.val()) {
                havemessage = true;
            }
            if (message.attr('ch') != $.md5(message.val()) || raty.attr('data-score') != raty.data('ra-value')) {
                hfdata.val(hfdata.val() + '#' + message.attr('rel') + '|' + message.val() + '|' + raty.data('ra-value'));
            }
        });
        if (!havemessage) {
            alert('请至少填写一项回复');
            return false;
        }
    }

    $('#btnSave').on('click', function () {
        return revalue();
    });

    $('.raty').raty({
        path: '../../images',
        size: 24,
        half: true,
        width: 150,
        click:function (score) {
            $(this).data('ra-value', score);
        },
        score: function () {
            $(this).data('ra-value', $(this).attr('data-score'));
            return $(this).attr('data-score');
        }
    });
});