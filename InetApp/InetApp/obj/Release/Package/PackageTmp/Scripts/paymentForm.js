$(document).ready(function () {
    var $field = $('input'),
    $zoomBtn = $('.zoomBtn'),
    $overlay = $('.overlay');

$field.on('focus', function() {
  $(this).parent().addClass('focus');
  $(this).parent().removeClass('active');
})

$field.on('blur', function() {
  $(this).parent().removeClass('focus');
  
  if ($(this).val() !== "") {
    $(this).parent().addClass('active');
  } else {
    $(this).parent().removeClass('active');
   // $('.iconCheck').hide();
  }
});


$zoomBtn.on('click', function() {
    showNumber();
});


$('.overlay button').on('click', function() {
  if($overlay.hasClass('show')){
    $overlay.hide();
    $overlay.removeClass('show');
    var correctCC = $('.overlay input').val();
    $('#cc').val(correctCC);
  }
})

function showNumber () {
    $overlay.show();
    $overlay.addClass('show');
    var cc = $('input#cc').val();
    $overlay.find('input').val(cc);
}

// Setup Cleave.js
var cleaveCreditCard = new Cleave('.credit_card_number', {
    creditCard:              true,
    onCreditCardTypeChanged: function (type) {
        if (selectedCardIcon) {
            DOM.removeClass(selectedCardIcon, 'active');
        }

        selectedCardIcon = DOM.select('.icon-' + type);

        if (selectedCardIcon) {
            DOM.addClass(selectedCardIcon, 'active');
        }
    }
});

var cleaveCreditCard2 = new Cleave('.credit_card_number2', {
    creditCard:              true,
    onCreditCardTypeChanged: function (type) {
        if (selectedCardIcon) {
            DOM.removeClass(selectedCardIcon, 'active');
        }

        selectedCardIcon = DOM.select('.icon-' + type);

        if (selectedCardIcon) {
            DOM.addClass(selectedCardIcon, 'active');
        }
    }
});

});