﻿function mensagem(titulo, tipo, frase, tempo, tamanho, icon) {

    new PNotify({
        icon: icon,
        title: titulo,//'SUCESSO',
        type: tipo,//'success',
        width: tamanho,
        text: "<h6>" + frase + "</h6>",
        nonblock: {
            nonblock: true,
            nonblock_opacity: .5
        },
        delay: parseInt(tempo),
        animate: {
            animate: true,
            in_class: 'bounceInDown',
            out_class: 'bounceOutUp'
        }
    });
}

function notify(from, align, icon, type, animIn, animOut, frase, titulo, tempo) {
    $.growl({
        icon: icon,
        title: '&nbsp;&nbsp;<b>' + titulo + '</b>',
        message: '</br><p>' + frase + '</p>',
        url: ''
    }, {
        element: 'body',
        type: type,
        allow_dismiss: true,
        placement: {
            from: from,
            align: align
        },
        offset: {
            x: 30,
            y: 30
        },
        spacing: 10,
        z_index: 999999,
        delay: tempo,
        timer: 1000,
        url_target: '_blank',
        mouse_over: false,
        animate: {
            enter: animIn,
            exit: animOut
        },
        icon_type: 'class',
        template: '<div data-growl="container" class="alert" role="alert">' +
            '<button type="button" class="close" data-growl="dismiss">' +
            '<span aria-hidden="true">&times;</span>' +
            '<span class="sr-only">Close</span>' +
            '</button>' +
            '<span data-growl="icon"></span>' +
            '<span data-growl="title"></span>' +
            '<span data-growl="message"></span>' +
            '<a href="#" data-growl="url"></a>' +
            '</div>'
    });
};

$('.notifications .btn').on('click', function (e) {
    e.preventDefault();
    var nFrom = $(this).attr('data-from');
    var nAlign = $(this).attr('data-align');
    var nIcons = $(this).attr('data-icon');
    var nType = $(this).attr('data-type');
    var nAnimIn = $(this).attr('data-animation-in');
    var nAnimOut = $(this).attr('data-animation-out');

    notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut);
});