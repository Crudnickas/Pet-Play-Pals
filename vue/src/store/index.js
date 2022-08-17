import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    dogBreeds: ["Australian Shepherd", "Beagle", "Bernese Mountain Dog","Boston Terrier","Boxer","Bulldog","Cane Corso","Cavalier King Charles Spaniel","Dachshund","Doberman Pinscher","French Bulldog","German Shepherd Dog","Golden Retriever","Great Dane","Havanese","Labrador Retriever","Miniature Schnauzer","Mixed Breed","Pembroke Welsh Corgi","Pointer (German Shorthaired)","Pomeranian","Poodle","Rottweiler","Shih Tzu","Siberian Huskie","Yorkshire Terrier"],
    petTemperament: ["Aggressive","Anxious","Bold","Calm","Friendly","Impulsive","Independent","Naughty","Neutral","Passive", "Playful", "Timid" ],

    petEnergy: ["Low", "Medium", "High"],
    pets: [],
    userRegisteredPets: [],
    petToPost: {},
    usernameToPost: "",
    playDateLocations: [
      {
        PlayParkName: "Peppy Paws Pooch Park, LLC",
        PlayParkAddress: "1046 County Road 1175, Ashland, OH 44805",
        PlayParkLocationNotes: "A 5-acre and 1-acre fenced park open daily from dawn until dusk. Day passes or annual passes are available for purchase."
      },
      {
        PlayParkName: "Willow Lake Campground",
        PlayParkAddress: "3935 N. Broadway, Geneva, OH 44041",
        PlayParkLocationNotes: "An 80 x 80 fenced area for campers"
      },
      {
        PlayParkName: "Aukerman Park",
        PlayParkAddress: "15561 York Rd., North Royalton, OH 44133",
        PlayParkLocationNotes: "An on-leash agility course with six stations including an A-frame ramp and teeter-totter."
      },
      {
        PlayParkName: "Downtown Cleveland Dog Park",
        PlayParkAddress: "1505 Merwin Ave., Cleveland, OH 44113",
        PlayParkLocationNotes: "The Downtown Dog Park provides nearly 3,500 square feet of fenced space featuring a play structure by Red House Projects, PUP waste receptacles and seating for humans"
      },
      {
        PlayParkName: "Lakewood Dog Park",
        PlayParkAddress: "1699 Valley Pkwy., Lakewood, OH 44107",
        PlayParkLocationNotes: "A 2/3-acre, off-leash exercise and play area. There is also a separate small dog area on the west end of the park. "
      },
      {
        PlayParkName: "Canine Meadow Dog Park",
        PlayParkAddress: "9010 Euclid Chardon Rd., Kirtland, OH 44094",
        PlayParkLocationNotes: "This off-leash dog park has a 2.57-acre large dog area with a swim area and a separate 1.02-acre small dog area."
      },
      {
        PlayParkName: "City of Mentor Dog Park",
        PlayParkAddress: "6647 Hopkins Rd., Mentor, OH 44060",
        PlayParkLocationNotes: "An off-leash dog park with separate areas for large and small dogs as well as a doggie water fountain, park benches, and a safe, fenced-in entry/exit area"
      },
      {
        PlayParkName: "Avon Lake Dog Park",
        PlayParkAddress: "33401 Webber Rd., Avon Lake, OH 44012",
        PlayParkLocationNotes: "An off-leash exercise area with agility structures"
      },
      {
        PlayParkName: "Splash Zone Dog Park",
        PlayParkAddress: "95 W. Hamilton Rd., Oberlin, OH 44074",
        PlayParkLocationNotes: "Located behind Splash Zone and open during Splash Zone’s open hours. The park sits on one acre and features two separate areas for large dogs and small dogs with one main entrance. Features include a shelter, shade trees, benches, and drinking fountain."
      },
      {
        PlayParkName: "Austintown Township Dog Park",
        PlayParkAddress: "6000 Kirk Rd., Austintown, OH 44515",
        PlayParkLocationNotes: "A fenced park with a 1/2-acre area with agility equipment and a 1/4-acre area for dogs 25 pounds and under."
      },
      {
        PlayParkName: "Marge Hartman's Paws-Town Dog Park",
        PlayParkAddress: "375 Boardman Poland Rd., Youngstown, OH 44512",
        PlayParkLocationNotes: "A 3.25-acre members-only fenced park located in Boardman Park. Features separate areas for small dogs. Several amenities include dog and human water fountains, dog waste bags, and a dog wash station. Pass required for entry."
      },
      {
        PlayParkName: "Brunswick Dog Park",
        PlayParkAddress: "Cross Creek Dr., Brunswick, OH 44212",
        PlayParkLocationNotes: "A .75-acre fenced area for off-leash exercise."
      },
      {
        PlayParkName: "Carolyn Ludwig Mugrage Park",
        PlayParkAddress: "Where: 4985 Windfall Rd., Medina, OH 44256",
        PlayParkLocationNotes: "Six-acre dog park completely enclosed by a five-foot-high fence that provides over an acre of space just for small dogs (under 30 lbs.) and a separate area for large dogs (over 30 lbs.). Both sides have open turf play areas, wooded natural areas, and gravel walking trails."
      },
      {
        PlayParkName: "Medina Memorial Park Dog Park",
        PlayParkAddress: "410 E. Homestead St., Medina, OH 44256",
        PlayParkLocationNotes: "A fenced-in area for off-leash exercise."
      },
      {
        PlayParkName: "Wadsworth Community Dog Park",
        PlayParkAddress: "618 West St., Wadsworth, OH 44281",
        PlayParkLocationNotes: "A 1-acre fenced area for smaller dogs (under 30 pounds) and a 2.58-acre area for larger dogs (over 30 pounds)."
      },
      {
        PlayParkName: "Tails ‘n Trails Dog Park",
        PlayParkAddress: " 841 Page Rd., Aurora, OH 44202",
        PlayParkLocationNotes: "A fenced area for off-leash exercise. This park features separate areas for large and small dogs, benches for owners, play features such as a fire hydrant, and a water well pump."
      },
      {
        PlayParkName: "Canal Fulton Dog Park",
        PlayParkAddress: "5500 Butterbridge Rd., Canal Fulton, OH 44614",
        PlayParkLocationNotes: "Fenced areas for dog exercise with a large and small dog area, picnic tables and benches, water for dogs, and a parking area."
      },
      {
        PlayParkName: "Furnas Park Off-Leash Dog Park",
        PlayParkAddress: "900 17th St. NE, Massillon, OH 44646",
        "PlayParkLocationNotes": "Located in Furnas Park, this area features separate fenced areas for large and small dogs."
      },
      {
        PlayParkName: "Ruff Run Membership Dog Park",
        PlayParkAddress: "732 Helmsworth Dr. NE, Canton, OH 44714",
        PlayParkLocationNotes: "Fenced off-leash area with separate large and small dog areas. Membership required and breed restrictions apply. Call for more information. "
      },
      {
        PlayParkName: "Veterans Park Dog Park",
        PlayParkAddress: "1714 Schneider St. NE, Canton, OH 44721",
        PlayParkLocationNotes: "Four-acre dog park with a 2.5-acre fenced area for large dogs and a 1.5-acre area for small dogs. Disposal bags provided for waste clean up."
      },
      {
        PlayParkName: "BARC – Akron Dog Park",
        PlayParkAddress: "499 Memorial Pkwy., Akron, OH 44310",
        PlayParkLocationNotes: "A fenced area for off-leash exercise with separate areas for large and small dogs. This park also offers benches, agility and play equipment, dog drinking fountain, and waste disposal stations."
      },
      {
        PlayParkName: "Bow Wow Beach Park",
        PlayParkAddress: "Silver Springs Park, 5027 Stow Rd., Stow, OH 44224",
        PlayParkLocationNotes: "Open mid-March through December 1st, this park offers a 7.5-acre fenced area with a 3-acre lake for the dogs to swim. There is a separate area for small dogs, dog washing station, and waste disposal area."
      },
      {
        PlayParkName: "Hudson Springs Park",
        PlayParkAddress: "7095 Stow Rd., Hudson, OH 44224",
        PlayParkLocationNotes: "There is an open area for small dogs permitted off-leash about a quarter mile down the trail."
      },
      {
        PlayParkName: "Keyser Dog Park",
        PlayParkAddress: "851 W. Bath Rd., Cuyahoga Falls, OH 44223",
        PlayParkLocationNotes: "Fenced area for off-leash exercise."
      },
      {
        PlayParkName: "Portage Lakes Dog Park",
        PlayParkAddress: "5031 Manchester Rd., Akron, OH 44319",
        PlayParkLocationNotes: "A fenced area for off-leash exercise with a dog swim area."
      },
      {
        PlayParkName: "Thomas Heritage Park",
        PlayParkAddress: "1050 Streetsboro Rd., Streetsboro, OH 44241",
        PlayParkLocationNotes: "A fenced area for off-leash exercise."
      },
      {
        PlayParkName: "Twinsburg Dog Park",
        PlayParkAddress: "9437 Liberty Rd., Twinsburg, OH 44087",
        PlayParkLocationNotes: "A fenced area for off-leash exercise."
      },
      {
        PlayParkName: "Wingfoot Lake State Park",
        PlayParkAddress: "993 Goodyear Park Blvd., Mogadore, OH 44260",
        PlayParkLocationNotes: "A fenced area for off-leash exercise."
      },
      {
        PlayParkName: "Cooperation Station Dog Park",
        PlayParkAddress: "Mosquito Lake State Park, 1439 State Route 305, Cortland, OH 44410",
        PlayParkLocationNotes: "A 5-acre fenced park with separate areas for large and small dogs as well as a dog swim area. Drinking water for dogs is provided seasonally"
      },
      {
        PlayParkName: "Wooster Dog Park",
        PlayParkAddress: "Shellin Park, 427 Maple St., Wooster, OH 44691",
        PlayParkLocationNotes: "A fenced area for off-leash exercise."
      }
     ]

  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
  SETPETTOPOST(state,pet) {
    state.petToPost = pet;
  },
  SAVE_PETS(state,pets){
    state.pets.push(pets);
  },
    // SETUSERNAMETOPOST(state, username) {
  //   state.usernameToPost = username;
  //    THIS NEEDS COMPLETED!
  // }
  // }
  }
})
