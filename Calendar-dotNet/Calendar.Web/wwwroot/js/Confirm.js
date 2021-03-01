function ConfirmDelete(message, element) {
    DayPilot.Modal.confirm(message, { theme: "modal_rounded" })
        .then(function (args) {
            if (args.result) {
                $.ajax({
                    type: "POST",
                    url: "/data/ReleaseUserReservaton",
                    data: {
                        reservationId: element.getAttribute("id")
                    },
                    success: function () {
                        window.location.reload(true);
                    },
                    error: function (error) {
                        alert('Something went wrong!');
                    }
                });
            }
        });
}