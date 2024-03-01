//let ingCount = 1;
//let stepCount = 1;

//$(document).ready(function () {
//    $("#addIngredientBtn").click(function () {
//        // make the last add Button invisible

//        // Create a new element
//        let newElement = `
//                          <li id="ingredient-${ingCount}">
//                            <input asp-for="IngredientName" class="form-control nameIngredient" placeholder="Ingredient:" />
//                            <span asp-validation-for="IngredientName" class=" small text-danger"></span>
//                            <input asp-for="IngredientAmount"class="form-control amountIngredient" placeholder="Amount:" />
//                            <span asp-validation-for="IngredientAmount" class=" small text-danger"></span>
//                            <select asp-for="@Model.MeasurmentId" class="form-control amountTypeIngredient" aria-required="true">
//                              @foreach (var type in Model.MeasurmentTypes)
//                                  {
//                                   <option value="@type.Id">@type.Name</option>
//                                  }
//                            </select>
//                            <span class="small text-danger"></span>
//                            <hr />
//                          </li>
//                          `;

//        ingCount++;
//        // Append the new element to the container
//        $("#ingredientList").append(newElement);
//    });

//    //removes the input field for the last ingredient
//    $("#removeIngredientBtn").click(function () {
//        if (ingCount > 1) {
//            ingCount--;
//            $(`#ingredient-${ingCount}`).remove();
//        }
//    })

//    $("#addStepBtn").click(function () {
//        // make the last add Button invisible

//        // Create a new element
//        let newElement = `
//                         <li id="step-${stepCount}">
//                            <input asp-for="StepDescription" id="stepInput-${stepCount}" class="form-control recepieStep" placeholder="Put your description here:" />
//                            <span asp-validation-for="StepDescription" class=" small text-danger"></span>
//                            <hr />
//                         </li>
//                         `;

//        stepCount++;
//        // Append the new element to the container
//        $("#stepsList").append(newElement);
//    });

//    $("#removeStepBtn").click(function () {
//        if (stepCount > 1) {
//            stepCount--;
//            $(`#step-${stepCount}`).remove();
//        }
//    })

//    //sends the ingredients as json
//    $("#submitBtn").click(function () {
//        let allIngredient = []

//        let names = [];
//        $(".nameIngredient").each(function () {
//            names.push($(this).val());

//        });

//        let amounts = [];
//        $(".amountIngredient").each(function () {
//            amounts.push($(this).val());

//        });

//        let types = [];
//        $(".amountTypeIngredient").each(function () {
//            types.push($(this).val());
//        });

//        let steps = [];
//        $(".amountTypeIngredient").each(function () {
//            types.push($(this).val());
//        });

//        for (let i = 0; i < ingCount; i++) {
//            let currIngredient = {
//                Name: names[i],
//                Amount: amounts[i],
//                AmountType: types[i],
//            }

//            allIngredient.push(currIngredient);
//        }

//        console.log(allIngredient);

//        $.ajax({
//            type: "Post",
//            url: "@Url.Action("Add")",
//            dataType: "json",
//            data: $.param({ allIngredient: JSON.stringify(allIngredient) }),
//            success: function (result) {
//                console.log(result);
//            },
//            error: function (req, status, error) {
//                console.log(status);
//            }
//        })

//    });
//})