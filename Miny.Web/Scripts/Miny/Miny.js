﻿var $container = $('#container');

$container.imagesLoaded(function () {
    $(function () {
        $('#container').masonry({
            itemSelector: '.item',
            columnWidth: 10,
            isFitWidth: true,
            isAnimated: true,
            animationOptions: {
                duration: 500,
                easing: 'linear',
                queue: false
            }
        });
    });
});

function ItemAdded(e) {
    if (e) {
        $("#container").prepend(e).masonry('reload');
    }
}

function ItemDeleted(e) {
    $("#container").masonry('remove', $('#item-' + e)).masonry('reload');
}

function isUrl(s) {
    var regexp = /(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/
    return regexp.test(s);
}

var watch = {

    check_input: function () {
        if (!$(this).is(':enabled')) return;
        watch.set($(this).attr('name'), $(this).val(), this);
    },

    values: {},
    triggers: {},

    add: function (name, fn) {
        if ($.type(name) == 'array') {
            return $.each(name, function () { watch.add(this, fn); });
        }

        if (this.triggers[name] == undefined) {
            this.triggers[name] = [];
            $(':input[name=' + name + ']').change(watch.check_input).keyup(watch.check_input).each(watch.check_input);
        }
        this.triggers[name].push(fn);
        if (this.values[name]) {
            fn.call(this.values[name][1], this.values[name][0]);
        }
        return watch;
    },

    get: function (name) {
        return this.values[name] && this.values[name][0];
    },
    set: function (name, value, el) {
        this.values[name] = [value, el];

        for (k in this.triggers[name]) {
            this.triggers[name][k].call(el, value);
        }
        return watch;
    }
};

watch.add('TestInput', function (value) { if (isUrl(value)) {  } });


