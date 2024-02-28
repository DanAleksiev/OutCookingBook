let ingredients = [];
let num = 1;
$(document).ready(function () {
    //generating the new element doesnt render measurments properly
    $("#addElementBtn").click(function () {
        // make the last add Button invisible

        // Create a new element
        let newElement = `
                                    <li id="ingredient-${num}">
                                      <input asp-for="IngredientName" id="ingredientName-${num}" class="form-control nameIngredient" placeholder="Ingredient:" />
                                      <span asp-validation-for="IngredientName" class=" small text-danger"></span>
                                      <input asp-for="IngredientAmount" id="ingredientAmount-${num}" class="form-control amountIngredient" placeholder="Amount:" />
                                      <span asp-validation-for="IngredientAmount" class=" small text-danger"></span>
                                      <select asp-for="@Model.MeasurmentId" id="amountTypeIngredient-${num}" class="form-control amountTypeIngredient" aria-required="true">
                                          @foreach (var type in Model.MeasurmentTypes)
                                          {
                                             <option value="@type.Id">@type.Name</option>
                                          }
                                      </select>
                                      <span class="small text-danger"></span>
                                      <hr />
                                    </li>
                                    `;

        num++;
        // Append the new element to the container
        $("#ingredientList").append(newElement);
    });

    //removes the input field for the last ingredient
    $("#removeElementBtn").click(function () {
        if (num > 1) {
            num--;
            $(`#ingredient-${num}`).remove();
        }
    })

    //sends the ingredients as json
    $("#submitBtn").click(function () {
        let allIngredient = []

        let names = [];
        $(".nameIngredient").each(function () {
            names.push($(this).val());

        });

        let amounts = [];
        $(".amountIngredient").each(function () {
            amounts.push($(this).val());

        });

        let types = [];
        $(".amountTypeIngredient").each(function () {
            types.push($(this).val());
        });

        for (let i = 0; i < num; i++) {
            let currIngredient = {
                Name: names[i],
                Amount: amounts[i],
                AmountType: types[i],
            }

            allIngredient.push(currIngredient);
        }

        console.log(allIngredient);

    });
})