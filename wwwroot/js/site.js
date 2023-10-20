const steps_div = document.getElementById("stepsdiv")
const ing_div = document.getElementById("ingdiv")

function AddNewStep() {
    const add_button = document.getElementById("addnewstep")
    const new_input = document.createElement("input")
    new_input.className = "form-control"
    new_input.type = "text"
    new_input.name = "Steps"
    new_input.id = "Steps"
    new_input.setAttribute("data-val", true)
    new_input.setAttribute("data-val-required", "The steps field is required.")

    steps_div.removeChild(add_button)
    steps_div.appendChild(new_input)

    const new_add_button = document.createElement("input")
    new_add_button.type = "button"
    new_add_button.id = "addnewstep"
    new_add_button.value = "+"
    new_add_button.addEventListener("click", AddNewStep)

    steps_div.appendChild(new_add_button)
}

function AddNewIngredient() {
    const add_button = document.getElementById("addnewing")
    const new_input = document.createElement("input")
    new_input.className = "form-control"
    new_input.type = "text"
    new_input.name = "Ingredients"
    new_input.id = "Ingredients"
    new_input.setAttribute("data-val", true)
    new_input.setAttribute("data-val-required", "The ingredients field is required.")

    ing_div.removeChild(add_button)
    ing_div.appendChild(new_input)

    const new_add_button = document.createElement("input")
    new_add_button.type = "button"
    new_add_button.id = "addnewing"
    new_add_button.value = "+"
    new_add_button.addEventListener("click", AddNewIngredient)

    ing_div.appendChild(new_add_button)
}

document.getElementById("addnewstep").addEventListener("click", AddNewStep)
document.getElementById("addnewing").addEventListener("click", AddNewIngredient)