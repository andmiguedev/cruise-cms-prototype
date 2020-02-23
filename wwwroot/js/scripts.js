/**
 * @Package: Complete Admin Theme
 * @Since: Complete Admin 1.0
 */

jQuery(function($) {

    'use strict';

    var CMPLTADMIN_SETTINGS = window.CMPLTADMIN_SETTINGS || {};

    /*--------------------------------
         Window Based Layout
     --------------------------------*/
    CMPLTADMIN_SETTINGS.windowBasedLayout = function() {
        var width = window.innerWidth;
        //console.log(width);

        if ($("body").hasClass("chat-open") || $("body").hasClass("sidebar-collapse")) {
            CMPLTADMIN_SETTINGS.mainmenuCollapsed();

        } else if (width < 767) {

            // small window
            $(".page-topbar").addClass("sidebar_shift").removeClass("chat_shift");
            $(".page-sidebar").addClass("collapseit").removeClass("expandit");
            $("#main-content").addClass("sidebar_shift").removeClass("chat_shift");
            $(".page-chatapi").removeClass("showit").addClass("hideit");
            $(".chatapi-windows").removeClass("showit").addClass("hideit");
            CMPLTADMIN_SETTINGS.mainmenuCollapsed();

        } else {

            // large window
            $(".page-topbar").removeClass("sidebar_shift chat_shift");
            $(".page-sidebar").removeClass("collapseit chat_shift");
            $("#main-content").removeClass("sidebar_shift chat_shift");
            CMPLTADMIN_SETTINGS.mainmenuScroll();
        }
    }



    /*--------------------------------
         Main Menu Scroll
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mainmenuScroll = function() {

        //console.log("expand scroll menu");

        var topbar = $(".page-topbar").height();
        //console.log(topbar);
        var projectinfo = 0; // $(".project-info").innerHeight();
        //console.log(projectinfo);

        var height = window.innerHeight - topbar - projectinfo;

        /*$('.fixedscroll #main-menu-wrapper').height(height).perfectScrollbar({
            suppressScrollX: true
        });*/
        if($('.fixedscroll #main-menu-wrapper').length){
            
            $('.fixedscroll #main-menu-wrapper').height(height);
            //console.log(height);
            const ps = new PerfectScrollbar('.fixedscroll #main-menu-wrapper', {
              suppressScrollX: true
            });

        }
            $("#main-menu-wrapper .wraplist").height('auto');


        /*show first sub menu of open menu item only - opened after closed*/
        // > in the selector is used to select only immediate elements and not the inner nested elements.
        $("li.open > .sub-menu").attr("style", "display:block;");

    };


    /*--------------------------------
         Collapsed Main Menu
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mainmenuCollapsed = function() {

        if ($(".page-sidebar.chat_shift #main-menu-wrapper").length > 0 || $(".page-sidebar.collapseit #main-menu-wrapper").length > 0) {
            //console.log("collapse menu");
            var topbar = $(".page-topbar").height();
            var windowheight = window.innerHeight;
            var minheight = windowheight - topbar;
            var fullheight = $(".page-container #main-content .wrapper").height();

            var height = fullheight;

            if (fullheight < minheight) {
                height = minheight;
            }

            //$('.fixedscroll #main-menu-wrapper').perfectScrollbar('destroy');
              if($('.fixedscroll #main-menu-wrapper').length){
                const ps = new PerfectScrollbar('.fixedscroll #main-menu-wrapper', {});
                ps.destroy();
            }

            $('.page-sidebar.chat_shift #main-menu-wrapper .wraplist, .page-sidebar.collapseit #main-menu-wrapper .wraplist').height(height);

            /*hide sub menu of open menu item*/
            $("li.open .sub-menu").attr("style", "");

        }
    };



    /*--------------------------------
         Main Menu
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mainMenu = function() {
        $('#main-menu-wrapper li a').click(function(e) {

            if ($(this).next().hasClass('sub-menu') === false) {
                return;
            }

            var parent = $(this).parent().parent();
            var sub = $(this).next();

            parent.children('li.open').children('.sub-menu').slideUp(200);
            parent.children('li.open').children('a').children('.arrow').removeClass('open');
            parent.children('li').removeClass('open');

            if (sub.is(":visible")) {
                $(this).find(".arrow").removeClass("open");
                sub.slideUp(200);
            } else {
                $(this).parent().addClass("open");
                $(this).find(".arrow").addClass("open");
                sub.slideDown(200);
            }

        });

        $("body").click(function(e) {
            $(".page-sidebar.collapseit .wraplist li.open .sub-menu").attr("style","");
            $(".page-sidebar.collapseit .wraplist li.open").removeClass("open");
            $(".page-sidebar.chat_shift .wraplist li.open .sub-menu").attr("style","");
            $(".page-sidebar.chat_shift .wraplist li.open").removeClass("open");
        });

    };


    /*--------------------------------
         DataTables
     --------------------------------*/
    CMPLTADMIN_SETTINGS.dataTablesInit = function() {

        if ($.isFunction($.fn.dataTable)) {

            /*--- start ---*/

            var tableex1 = $("#example-1").dataTable({
                responsive: true,
                aLengthMenu: [
                    [10, 25, 50, 100, -1],
                    [10, 25, 50, 100, "All"]
                ]
            });

            /*--- end ---*/
        }
    };


    /******************************
     initialize respective scripts 
     *****************************/
    $(document).ready(function() {
        CMPLTADMIN_SETTINGS.windowBasedLayout();
        CMPLTADMIN_SETTINGS.mainmenuScroll();
        CMPLTADMIN_SETTINGS.mainMenu();
        CMPLTADMIN_SETTINGS.mainmenuCollapsed();
    });

    $(window).resize(function() {
        CMPLTADMIN_SETTINGS.windowBasedLayout();
    });

  
});
