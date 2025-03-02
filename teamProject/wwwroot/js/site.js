function confirmDelete(id, route) {
    Swal.fire({
        title: "Are you sure you want to delete?",
        text: "You Can't Go Back!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#d33",
        cancelButtonColor: "#3085d6",
        confirmButtonText: "Delete",
        cancelButtonText: "Cancel"
    }).then((result) => {
        if (result.isConfirmed) {
            let token = document.querySelector("input[name='__RequestVerificationToken']")?.value;

            fetch(route, {
                method: "POST",
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded",
                    "X-Requested-With": "XMLHttpRequest"
                },
                body: `id=${id}&__RequestVerificationToken=${token}`
            })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    Swal.fire("Deleted!", "The item has been deleted.", "success")
                        .then(() => location.reload());
                } else {
                    Swal.fire("Error!", data.message || "Something went wrong.", "error");
                }
            })
            .catch(error => {
                console.error("Fetch Error:", error);
                Swal.fire("Error!", "Something went wrong.", "error");
            });
        }
    });
}

