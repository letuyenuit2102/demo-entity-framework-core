var deleteCategories = document.querySelectorAll("#deleteCategory")
var deleteAllCategory = document.getElementById("deleteAllCategory")
var allCheckBoxs = document.querySelectorAll(".check-box-all")
var selectAllCategory = document.getElementById("selectAll");
var arrayChecked = []
deleteAllCategory.disabled = arrayChecked.length > 0 ? false : true
for (var i = 0; i < deleteCategories.length; i++) {
    deleteCategories[i].addEventListener("click", e => {
        e.preventDefault();
        var idCate = e.currentTarget.dataset.id
        console.log(idCate)
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                const xmlhttp = new XMLHttpRequest();
                xmlhttp.onload = function () {
                    document.querySelector(`.tr-${idCate}`).style.display = "none"
                    Swal.fire(
                        'Deleted!',
                        'Your file has been deleted.',
                        'success'
                    )
                }
                xmlhttp.open("POST", `/Category/DeleteCategory/${idCate}`);
                xmlhttp.send();
            }
        })
    })
}
var count = 0;
for (var i = 0; i < allCheckBoxs.length; i++) {
    allCheckBoxs[i].addEventListener("change", e => {
        const allChecked = Array.from(allCheckBoxs).every(checkbox => checkbox.checked);
        const eachChecked = Array.from(allCheckBoxs).some(checkbox => checkbox.checked);
        selectAllCategory.checked = allChecked;
        deleteAllCategory.disabled = !eachChecked;
    })
}
selectAllCategory.addEventListener("change", e => {
        for (var i = 0; i < allCheckBoxs.length; i++) {
            allCheckBoxs[i].checked = e.currentTarget.checked
    }

    if (e.currentTarget.checked) {
        deleteAllCategory.disabled = false
    }
    else {
        deleteAllCategory.disabled = true
    }
})
deleteAllCategory.addEventListener("click", e => {
    e.preventDefault();
    allCheckBoxs.forEach(checkbox => {
        if (checkbox.checked) {
            arrayChecked.push(checkbox.dataset.id);
        }
    })
    var ids = Array.from(arrayChecked)
    var group = { 'ids': ids };
    $.ajax({
        dataType: 'json',
        type: "POST",
        url: "/Category/DeleteMultipleCategory",
        data: group,
        success: function (data) {
            console.log("output : " + JSON.stringify(data));
        },
        error: function (data) {
            console.log("error : " + JSON.stringify(data));
        },
    });
    //let post = JSON.stringify(group)
    //const xmlhttp = new XMLHttpRequest();
    //xmlhttp.onload = function () {

    //}
    //xmlhttp.open("POST", "/Category/DeleteMultipleCategory", true);
    //xmlhttp.setRequestHeader('Content-type', 'application/json; charset=UTF-8')
    //xmlhttp.send(post);
})
const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
const page = urlParams.get('page')
console.log(typeof (page));
document.querySelectorAll("#page-item-number").forEach((pag, idx) => {
    var currenPage = pag.dataset.page
    if (+currenPage === +page) {
        pag.className += " active"
    }
    if (!page && idx === 0) {
        pag.className += " active"
    }
})