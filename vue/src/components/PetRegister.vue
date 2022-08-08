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
        <option value="puppy">Puppy (under 1 year)</option>
        <option value="adult">Adult (1 to 9 years)</option>
        <option value="senior">Senior (10 to 13 years</option>
        <option value="geriatric">Geriatric (14 plus years)</option>
        
    </select>
    <br>
          <label for="petSize" class="sr-only">Pet Size: </label>
        <select name="petSize" id="petSize" v-model="pet.size">
        <option disabled value = ""> Please Select one </option>
        <option value="mini">Mini (under 10lbs)</option>
        <option value="small">Small (11 to 20lbs) </option>
        <option value="medium">Medium (21 to 50lbs)</option>
        <option value="large">Large (greater than 50lbs)</option>
        
       
    </select>
       <br>
          <label for="petBreed" class="sr-only">Pet Breed: </label>
        <select name="petBreed" id="petBreed" v-model="pet.breed"> 
        <option disabled value = ""> Please Select one </option>
        <option
      v-for="breed in $store.state.dogBreeds"
      v-bind:key="breed.id">
      {{breed}}
    </option>
    </select>
      <br>
          <label for="petTemperament" class="sr-only">Pet Temperament: </label>
        <select name="petTemperament" id="petTemperament" v-model="pet.temperament"> 
        <option disabled value = ""> Please Select one </option>
        <option
      v-for="temperament in $store.state.petTemperament"
      v-bind:key="temperament.id">
      {{temperament}}
    </option>
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