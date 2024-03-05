//removes the input field for the last ingredient
let ingCount = 1;
let stepCount = 1;

$(document).ready(function () {
    document.getElementById("successSaved").style.display = "none";
    document.getElementById("submitBtn").style.display = "none";
    $("#addElementBtn").click(function () {
        // make the last add Button invisible

        // Create a new element
        let newElement = `
                                                                <li id="ingredient-${ingCount}">
                                                          <input asp-for="IngredientName" class="form-control nameIngredient" placeholder="Ingredient:" />
                                                          <span asp-validation-for="IngredientName" class=" small text-danger"></span>
                                                          <input asp-for="IngredientAmount"class="form-control amountIngredient" placeholder="Amount:" />
                                                          <span asp-validation-for="IngredientAmount" class=" small text-danger"></span>
                                                          <select asp-for="@Model.MeasurmentId" class="form-control amountTypeIngredient" aria-required="true">
        @foreach (var type in Model.MeasurmentTypes)
            {
                                                                                 <option value="@type.Id">@type.Name</option>
            }
                                                         </select>
                                                         <span class="small text-danger"></span>
                                                         <hr />
                                                       </li>
                                                       `;

        ingCount++;
        // Append the new element to the container
        $("#ingredientList").append(newElement);
    });
    $("#removeElementBtn").click(function () {
        if (ingCount > 1) {
            ingCount--;
            $(`#ingredient-${ingCount}`).remove();
        }
    });

    $("#addStepBtn").click(function () {
        // make the last add Button invisible

        // Create a new element
        let newElement = `
        <li id="step-${stepCount}">
           <input asp-for="StepDescription" id="stepInput-${stepCount}" class="form-control recepieStep" placeholder="Put your description here:" />
           <span asp-validation-for="StepDescription" class=" small text-danger"></span>
           <hr />
        </li>
        `;

        stepCount++;
        // Append the new element to the container
        $("#stepsList").append(newElement);
    });

    $("#removeStepBtn").click(function () {
        if (stepCount > 1) {
            stepCount--;
            $(`#step-${stepCount}`).remove();
        }
    });

    //<script src="~/js/btnFunctions.js"></script>
})