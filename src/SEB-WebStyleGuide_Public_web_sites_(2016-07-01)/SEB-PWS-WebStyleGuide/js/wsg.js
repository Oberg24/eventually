var WSG = WSG || {};

$(document).ready(function() {
  WSG.Init();  
});

WSG = (function () {

  var wsg = {};

  wsg.Init = function () {    
    this.HideToggable();
    this.ActivateScrollSpy();
    this.DisableExampleLinkClick();
    this.ShowHideCodeClick();
    this.ResponsivTables();
    
    $("[data-toggle=popover]").popover();
    
  };

  wsg.HideToggable = function () {
    $(".toggable").hide();
  };

  wsg.ActivateScrollSpy = function () {
    $(".navbar-right .nav > li").on("activate.bs.scrollspy", function () {
      $(".nav > li").find(".secondary").hide();
      $(".nav > li.active").find(".secondary").show();
    });
  };

  wsg.ShowHideCodeClick = function () {
    $(".code-lock").on("click", function (e) {
      e.preventDefault();
      $(this).next(".toggable").toggle();
    });
  };

  wsg.DisableExampleLinkClick = function () {
    $(".do-not-link").on("click", function (e) {
      e.preventDefault();
    });
  };

  wsg.ResponsivTables = function () {
      if ($('.financialtable, .static-left-column').length) {
          $('.financialtable tbody tr th:first-child, .financialtable thead tr th:first-child, .static-left-column tbody tr td:first-child, .static-left-column thead tr th:first-child').each(function () {
              var element = $(this);
              element.data('origPosition', {
                  oTop: element.position().top,
                  oLeft: element.position().left,
                  oWidth: element.width(),
                  oHeight: element.height()
              });
              setTimeout(function () {
                  element.css({
                      position: 'absolute',
                      top: element.data('origPosition').Top,
                      left: element.data('origPosition').oLeft,
                      width: element.data('origPosition').oWidth,
                      height: element.data('origPosition').oHeight
                  });
                  element.siblings().css('height', element.data('origPosition').oHeight + 'px');
              }, 0);
          });
          $('.financialtable tbody tr th:nth-child(2), .financialtable thead tr th:nth-child(2), .static-left-column tbody tr td:nth-child(2), .static-left-column thead tr th:nth-child(2)').each(function () {
              var element = $(this);
              var width = element.parents('table').find('tr th:first-child').width();
              setTimeout(function () {
                  element.css('padding-left', (width + 40) + 'px');
              }, 0);
          });
          $('.financialtable, .static-left-column').on('scroll', function () {
              var sLeft = $(this).scrollLeft();
              //sTop = $(this).scrollTop();
              $(this).find('thead tr th:first-child, tbody tr th:first-child, tbody tr td:first-child').each(function () {
                  $(this).css({
                      'left': sLeft + $(this).data('origPosition').oLeft
                  });
              });
          });
      }
  }
  return wsg;

})();





