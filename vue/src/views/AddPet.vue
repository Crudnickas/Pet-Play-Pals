<template>
<div id=addPetPage>
<global-menu/>
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
import GlobalMenu from '../components/GlobalMenu.vue'

export default {
    name: "add-pet",
    components: {
        PetRegister,
        GlobalMenu
  },
  data(){
    return{
       petUserObject: {
        username: "",
        petId: "",
      },
      errorMessage: "There were problems registering this pet."
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

          });
       
      }
      })
      .catch((error) => {
        const response = error.response;
        if(response.status === 404){
           this.errorMessage = error.message;
        
        }

      });
   
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