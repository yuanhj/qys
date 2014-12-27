$().ready(function () {
    $('.raty').raty({
        path: '../../images',
        size: 24,
        half: true,
        width: 150,
        readOnly: true,
        score: function () {
            return $(this).attr('data-score');
        }
    });
});