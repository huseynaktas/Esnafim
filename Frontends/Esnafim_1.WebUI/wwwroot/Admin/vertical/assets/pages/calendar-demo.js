/*
 Template Name: Xacton - Admin & Dashboard Template
 Author: Myra Studio
 File: Calendar (API consume version)
*/

!function ($) {
    "use strict";

    var CalendarPage = function () { };

    CalendarPage.prototype.init = function () {

        if (!$.isFunction($.fn.fullCalendar)) {
            console.log("FullCalendar plugin not found.");
            return;
        }

        // ✅ external events kısmı (sayfada yoksa patlamasın)
        if ($("#external-events").length > 0) {
            $('#external-events .fc-event').each(function () {

                var eventObject = {
                    title: $.trim($(this).text())
                };

                $(this).data('eventObject', eventObject);

                // jQuery UI draggable varsa
                if ($.isFunction($.fn.draggable)) {
                    $(this).draggable({
                        zIndex: 999,
                        revert: true,
                        revertDuration: 0
                    });
                }
            });
        }

        // ✅ double-init olursa takvim görünmeyebilir / bozulabilir
        if ($('#calendar').data('fullCalendar')) {
            $('#calendar').fullCalendar('destroy');
        }

        // ✅ businessId sayfada tanımlı mı?
        // View'da: const businessId = @(ViewBag.BusinessId ?? 0);
        if (typeof businessId === "undefined") {
            console.log("businessId is undefined. View tarafında JS'e basılmalı.");
            return;
        }

        $('#calendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,basicWeek,basicDay'
            },
            editable: false,    // update endpoint yoksa false kalsın
            droppable: false,   // drop ile ekleme yapılmıyor
            eventLimit: true,

            // ✅ events artık server'dan çekiliyor
            events: function (start, end, timezone, callback) {
                $.ajax({
                    url: '/BusinessOwner/BusinessOwnerCalendar/GetEvents',
                    dataType: 'json',
                    data: {
                        businessId: businessId,
                        start: start.format(),
                        end: end.format()
                    },
                    success: function (res) {
                        callback(res);
                    },
                    error: function (xhr) {
                        console.log("GetEvents error:", xhr.status, xhr.responseText);
                        callback([]);
                    }
                });
            }
        });
    };

    $.CalendarPage = new CalendarPage;
    $.CalendarPage.Constructor = CalendarPage;

}(window.jQuery);

// initializing (document ready ile garanti)
(function ($) {
    "use strict";
    $(document).ready(function () {
        $.CalendarPage.init();
    });
})(window.jQuery);
