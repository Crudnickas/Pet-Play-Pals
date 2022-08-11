<template>
<div id=addPetPage>
<pet-register/>
<div id= "AddPetSubmitCancel">
<button class = "submitButton" type="submit" value="Submit" v-on:click="addNewPet">Submit</button>
<button type="cancel" value="Cancel" v-on:click ="cancelButton">Cancel</button>
</div>
</div>
</template>

<script>
import PetRegister from '../components/PetRegister.vue'
import PetService from '../services/PetService';
export default {
    name: "add-pet",
    components: {
        PetRegister,
  },
  data(){
    return{
       petUserObject: {
        username: "",
        petId: "",
      }
    }
  },
  methods:{
    cancelButton(){
       this.$router.push("/");
      
    },
    addNewPet(){
       this.petUserObject.username = this.$store.state.user.username;
      PetService.createPet(this.$store.state.petToPost)
      .then((response) => {
        if (response.status == 201){
          this.petUserObject.petId = response.data.petId;

        PetService.createPetRelationship(this.petUserObject).then(
          (response)=>{
            if(response.status == 200){
              this.$router.push({
                path: '/',

              });
            }

          }
       
        )
        }
      })
   
    }
  },
};
    
</script>

<style>
.submitButton{
  margin-right: 10px;

}
#AddPetSubmitCancel{
  display:flex;
  justify-content: center;
}

</style>