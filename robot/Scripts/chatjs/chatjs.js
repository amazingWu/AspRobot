/*
jQ向上滚动带上下翻页按钮
*/
(function ($) {
    $.fn.extend({
        Scroll: function (opt, callback) {
            //参数初始化
            if (!opt) var opt = {};
            var timerID;
            //var _this = this.eq(0).find("ul:first");
            var speed = opt.speed ? parseInt(opt.speed, 10) : 500; //卷动速度，数值越大，速度越慢（毫秒）
            timer = opt.timer //?parseInt(opt.timer,10):3000; //滚动的时间间隔（毫秒）
            var upHeight =$("ul").height-$(window).height();//高度
            //滚动函数
            var scrollUp = function () {
                _this.animate({
                    marginTop: upHeight
                }, speed);

            }

        }
    })
})(jQuery);
