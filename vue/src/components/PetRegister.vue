<template>
<form class="form-register" @submit.prevent="register">
     <label for="petName" class="sr-only">Pet Name: </label>
      <input
        type="text"
        id="petName"
        class="form-control"
        placeholder="Pet Name"
        v-model="pet.name"
      />
      <br>
      <!-- THIS NEEDS TO BE added with the right information -->
       <label for="petAge" class="sr-only">Pet Age: </label>
        <select name="petAge" id="petAge" v-model="pet.age">
        <option disabled value = ""> Please Select one </option>
        <option value="puppy">Puppy (under 1 Year)</option>
        <option value="adult">Adult (1 to 9 years)</option>
        <option value="mercedes">Mercedes</option>
        <option value="audi">Audi</option>
        
    </select>
    <br>
          <label for="petSize" class="sr-only">Pet Size: </label>
        <select name="petSize" id="petSize" v-model="pet.size">
        <option disabled value = ""> Please Select one </option>
        <option value="volvo">Volvo</option>
        <option value="saab">Saab</option>
        <option value="mercedes">Mercedes</option>
        <option value="audi">Audi</option>
        
    </select>


</form>
  
</template>

<script>
export default {
name: 'pet-register',
data(){
    return{
        pet:{
            name:"",
            age:"",
            size:"",
            breed:"",
            temperament:"",
            energy:"",
            bio:""
        }
    }
}
}
</script>

<style>

</style>