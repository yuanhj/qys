$().ready(function () {
    $('.star').raty({
        readOnly: true,
        score: function () {
            return $(this).attr('data-score');
        },
        size: 24,
        half: true,
        width: 210,
        path:'images'
    });
    

    $('.de-star').raty({
        readOnly: function () {
            if ($(this).attr('data-score') && $(this).attr('data-score') * 1.0 > 0) {
                return true;
            }
            return false;
        },
        score: function () {
            return $(this).attr('data-score');
        },
        click: function (score) {
            if (confirm('您只有一次评分的机会！')) {
                var id = $(this).attr('rel');
                $.ajax({
                    type: 'post',
                    url: 'handler/demand.ashx',
                    data: {ac:'raty', id: id, raty: score },
                    success: function (html) {
                        var json = eval("(" + html + ")");
                        if (json.result != '0') {
                            if (json.message) {
                                alert(json.message);
                                location.href = "Login.aspx";
                            } else if(json.result=='-1'){
                                alert("请先登录！");
                                location.href = "Login.aspx";
                            } else if(json.result=='-2'){
                                alert("只能评论自己发布的诉求！");
                            }
                            else if (json.result == '-3') {
                                alert("不能重复评论");
                            } else {
                                alert("评分失败！");
                            }
                            $(this).raty('reload');
                        }
                    }
                });
            } else {
                $(this).raty('reload');
            }
        },
        size: 24,
        half: true,
        width: 195,
        path:'images'
    });
    




    $('.stars').raty({
        readOnly: true,
        score: function () {
            return $(this).attr('data-score');
        },
        size: 24,
        half: true,
        width: 150,
        path: 'images'
    });
    
    $('.stars2').raty({
        readOnly: true,
        score: function () {
            return $(this).attr('data-score');
        },
        size: 24,
        half: true,
        width: 190,
        path: 'images'
    });
    $('.starss').raty({
        readOnly: true,
        score: function () {
            return $(this).attr('data-score');
        },
        size: 24,
        half: true,
        width: 260,
        path: 'images'
    });
    $('.starss2').raty({
        readOnly: true,
        score: function () {
            return $(this).attr('data-score');
        },
        size: 24,
        half: true,
        width: 115,
        path: 'images'
    });
});