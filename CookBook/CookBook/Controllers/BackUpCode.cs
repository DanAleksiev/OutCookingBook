using CookBook.Infrastructures.Data.Models.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Collections.Specialized.BitVector32;

namespace CookBook.Controllers
    {
    public class BackUpCode
        {
        //    @*     <script>
        //    $('#partialRender').load("/Recepie/AddIngredientPartial")
        //</script> *@

        //@* <script>
        //    $("#submit-btn").click(function () {

        //        $.ajax({
        //        type: "GET",
        //            url: "@Url.Action("GetNames")",
        //            dataType: "json",
        //            success: function(result) {
        //                // console.log(result);
        //                },
        //            error: function(req, status, error) {
        //                // console.log(status);
        //                }
        //            })

        //        $.ajax({
        //        type: "Post",
        //            url: "@Url.Action("PostNames")",
        //            dataType: "json",
        //            data: { name: "Jannik" },
        //            success: function(result) {
        //                // console.log(result);
        //                },
        //            error: function(req, status, error) {
        //                // console.log(status);
        //                }
        //            })
        //    })
        //</script> *@
        // var name = $('.nameIngredient').val();
        // var amount = $('.amountIngredient').val();
        // var type = $('.amountTypeIngredient').val();
        // num++

        // // Create a new Ingredient object
        // var ingredient = {
        //     "Name": name,
        //     "Amount": amount,
        //     "AmountType": type
        // };
        // ingredients.push(ingredient);
        // // // Now you can do something with the new ingredient object
        // console.log(ingredient);
        // console.log(ingredients);

        // function GetIngrediants() {
        // var mvar = "";
        //     $(".ingredient").each(function () {
        //         console.log($(this).html());
        //         mvar += $(this).html();
        //     });
        // }

        //it kind of works but it need to be in object with those val!!
        // $('#sub-ing-btn').click(function () {

        //     let names = [];
        //     $(".nameIngredient").each(function () {
        //         console.log($(this).val());
        //         mvar.push($(this).val());

        //     });
        //     let amounts[]
        //     $(".amountIngredient").each(function () {
        //         console.log($(this).val());
        //         mvar.push($(this).val());

        //     });
        //     let types = []
        //     $(".amountTypeIngredient").each(function () {
        //         console.log($(this).val());
        //         mvar.push($(this).val());

        //     });
        //     console.log(mvar)
        // var name = $('.nameIngredient').val();
        // var amount = $('.amountIngredient').val();
        // var type = $('.amountTypeIngredient').val();

        // var all = $(".nameIngredient").map(function () {
        //     return this.nodeValue;
        // }).get();


        // console.log(all.join());
        // // Create a new Ingredient object
        // var ingredient = {
        //     "Name": name,
        //     "Amount": amount,
        //     "AmountType": type
        // };
        // ingredients.push(ingredient);
        // // // Now you can do something with the new ingredient object
        // console.log(ingredient);
        // console.log(ingredients);


        // $.ajax({
        //     type: "Post",
        //     url: "@Url.Action("PostIngredients")",
        //     dataType: "json",
        //     data: mvar,
        //     success: function (mvar) {
        //         console.log(mvar);
        //     },
        //     error: function (req, status, error) {
        //         console.log(status);
        //     }
        // })
        //})




        //genterate ne element

        //let ingredients = [];
        //let num = 1;
        //$(document).ready(function () {
        //    $("#addElementBtn").click(function() {
        //        // Create a new element
        //        var newLi = document.createElement("li");

        //        //add class to the new li
        //        newLi.classList.add(..."ingredient-" + num);
        //        num++;
        //        // Add input elements to the new li
        //        newLi.innerHTML = `
        //                        < input class="form-control nameIngredient" placeholder="Ingredient:" />
        //                        <input class="form-control amountIngredient" placeholder="Amount:" />
        //                        <input class="form-control amountTypeIngredient" placeholder="T.S./G/Cups" />
        //                        <span class="small text-danger"></span>
        //                        <span class=" small text-danger"></span>
        //                        <hr />
        //                        <hr />
        //                        `;

        //        // Append the new element to the container
        //        $("#ingredientList").append(newLi);
        //});




        //List<Ingredient> tempIng = new List<Ingredient>() {
        //        new Ingredient()
        //            {
        //            Name = "temp1",
        //            Amount = 2,
        //            MeasurementId = 20,
        //            },
        //        new Ingredient()
        //            {
        //            Name = "temp2",
        //            Amount = 3,
        //            MeasurementId = 20,
        //            },
        //        };

        //List<Step> stepIng = new List<Step>() {
        //        new Step()
        //            {
        //            Position = 1,
        //            Description = "BlahBlahBlah"
        //            },
        //        new Step()
        //            {
        //            Position = 2,
        //            Description = "BlahBlahBlah"
        //            },
        //        };
        //await Console.Out.WriteLineAsync("Add Method !");
//        @* 
//@section Scripts
//            {
//    <script>

//        $(document).ready(function () {
//            let allIngredient = [
//                {
//            Name: "Hlqb",
//                    Amount: 2,
//                    AmountType: 3,
//                },
//                {
//            Name: "corn",
//                    Amount: 2,
//                    AmountType: 1,
//                },
//                {
//            Name: "Flower",
//                    Amount: 3,
//                    AmountType: 3,
//                },
//            ];

//            let steps = [
//                {
//            Description: "BlahBlahBlah",
//                    Position: 1,
//                }, 
//                {
//            Description: "tepetepetpep",
//                    Position: 2,
//                },
//                {
//            Description: "yapayapayapa",
//                    Position: 3,
//                },
//            ]


            // $.ajax({
            //     type: "GET",
            //     url: "@Url.Action("GETIngredients")",
            //     dataType: "json",
            //     success: function (result) {
            //         console.log(result);
            //     },
            //     error: function (req, status, error) {
            //         console.log(status);
            //     }
            // })

            // $.ajax({
            //     type: "POST",
            //     url: "@Url.Action("POSTIngredients")",
            //     contentType: "application/json; charset=utf-8",
            //     dataType: "json",
            //     data: name,
            //     success: function (result) {
            //         console.log(result);
            //     },
            //     error: function (req, status, error) {
            //         console.log(status);
            //     }

            // });
    //        $.ajax({
    //        type: "Post",
    //            url: "@Url.Action("POSTIngredients")",
    //            dataType: "json",
    //            data: $.param({
    //            allIngredient: JSON.stringify(allIngredient),
    //                steps: JSON.stringify(steps),
    //            }),
    //            success: function(result) {
    //                // alert(JSON.stringify(result))
    //                },
    //            error: function(req, status, error) {
    //                // console.log(status);
    //                }
    //            });
    //        });

    //</script> 
        }
    }
