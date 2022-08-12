<template>
<form action="">
<h2>Schedule a PlayDate:</h2>
<div id="selectYourPet">
 <label id="petDropDownLabel" for="petdropdown" class="sr-only">Select pets to attend playdate: </label>
<multiselect  id="muliselectPetDropdown" v-for="pet in pet" v-bind:key="pet.petId"
v-model="petArray"
>

</multiselect>
</div>

<button class = "submitButton" type="submit" value="Submit" v-on:click="addNewPet">Submit</button>
<button type="cancel" value="Cancel" v-on:click ="cancelButton">Cancel</button>

</form>

  
</template>

<script>
import Multiselect from 'vue-multiselect'

export default {
name: 'schedule-playdate-form',
components:{
    Multiselect
},
data(){
    return{
    petArray:[],
    }
}
}
</script>

<style>

</style>