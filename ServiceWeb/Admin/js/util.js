$().ready(function () {
    $('.btncfm').on('click', function () {
        return confirm($(this).attr('rel') ? $(this).attr('rel') : '确定?');
    });
});