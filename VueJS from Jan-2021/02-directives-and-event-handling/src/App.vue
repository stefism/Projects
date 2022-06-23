<template>
  <div>
    <h1>Gallery</h1>
    <div>
      <span>Favourite images: {{favCount}}</span>
      <br/>
      <span>Favourite images with computed property: {{computedFavCount}}</span>
      <br/>
      <span>{{hasTooMany ? 'Too many images.' : ''}}</span>
    </div>
    <div class="controls">
      <span>Filter by:</span>
      <button @click="onFilter('nature')">Nature</button>
      <button @click="onFilter('ocean')">Ocean</button>
      <button @click="onFilter('reset')">Reset</button>
    </div>
    <ul class="imageList">
      <li class="item" v-for="(item, index) in filteredItems" :key="index">
        <img @click="addToFavourites(index)" 
              class="image" 
              :src="item.url" 
              :alt="`${item.type}-picture-${index}`"
              :class="{ saved: item.saved }"
        />
        <!-- :src, :alt - за да приема променливи динамично, а не като стринг, задължително двете точки преди пропертито се слагат. -->
        <!-- :class="{ saved: item.saved }" - Ако item.saved е true ще добави към img елемента клас saved. -->
      </li>
    </ul>
    <div>
      <h1>Random Numbers</h1>
      <p>The number {{number}} is {{numberType}}.</p>
      <button @click="generateRandomNumber">New random number</button>
    </div>
  </div> 
</template>

<script>
const data = [
        {
          saved: false,
          type: "nature",
          url: "https://cdn.pixabay.com/photo/2014/02/27/16/10/tree-276014__340.jpg"
        },
        {
          saved: false,
          type: "nature",
          url: "https://images.unsplash.com/photo-1610878180933-123728745d22?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8Y2FuYWRhJTIwbmF0dXJlfGVufDB8fDB8fA%3D%3D&w=1000&q=80"
        },
        {
          saved: false,
          type: "nature",
          url: "https://upload.wikimedia.org/wikipedia/commons/c/c8/Altja_jõgi_Lahemaal.jpg"
        },
        {
          saved: false,
          type: "nature",
          url: "https://media.istockphoto.com/photos/mountain-landscape-picture-id517188688?k=20&m=517188688&s=612x612&w=0&h=i38qBm2P-6V4vZVEaMy_TaTEaoCMkYhvLCysE7yJQ5Q="
        },
        {
          saved: false,
          type: "nature",
          url: "https://cdn.pixabay.com/photo/2015/12/01/20/28/road-1072823__340.jpg"
        },
        {
          saved: false,
          type: "ocean",
          url: "https://www.campusfrance.org/sites/default/files/medias/images/2022-02/Ocean.jpg"
        },
        {
          saved: false,
          type: "ocean",
          url: "https://www.thoughtco.com/thmb/t8AnhGOqEJEaehpyjAL3yGafxnA=/3439x2579/smart/filters:no_upscale()/GettyImages_482194715-56a1329e5f9b58b7d0bcf666.jpg"
        },
        {
          saved: false,
          type: "ocean",
          url: "https://oceanvisions.org/wp-content/uploads/2021/09/joseph-barrientos-oQl0eVYd_n8-unsplash-Custom.jpg"
        },
        {
          saved: false,
          type: "ocean",
          url: "https://res.cloudinary.com/dtpgi0zck/image/upload/s--SsFGdDoP--/c_fill,h_580,w_860/v1/EducationHub/photos/ocean-waves.jpg"
        },
        {
          saved: false,
          type: "ocean",
          url: "https://imageio.forbes.com/specials-images/imageserve/6058b1eed388d3a4a0831d09/960x0.jpg?format=jpg&width=960"
        }
];

export default {
  name: 'App',
  data() {
    return {
      filteredItems: [...data],
      favCount: 0,
      number: 0,
      numberType: ''
    };
  },
  watch: {
    favCount: function(newValue, oldValue) {
      console.log(`Watcher old: ${oldValue}, Watcher new: ${newValue}`);
    },
    // eslint-disable-next-line no-unused-vars
    number: function(newValue, oldValue) {
      const isEven = newValue % 2 == 0;
      this.numberType = isEven ? 'even' : 'odd';
    }
  },
  //Уочърите следят за промяна на стойността на някое от нашите пропертита. За целта се пише точното име на пропертито, чиято стойност ще следим и след това функция, която приема старата стойност и новата стойност. Всеки уочър следи само за едно проперти. Както се предполага, функцията (watcher-a) се активира винаги когато имаме промяна в следеното проперти. Примерно може да се ползва, ако се промени потребителското име или паролата, да изпрати и-мейл до потребителя.
  computed: {
    computedFavCount() {
      let count = 0;

      this.filteredItems.forEach(i => {
        if(i.saved) {
          count++;
        }
      });

      return count;
    },
    hasTooMany() {
      return this.favCount > 3 ? true : false;
    }
  },
  //Компютед пропертитата са функции, които се викат автоматично щом нещо в пропертито се промени. Имат сетер в себе си и се викат без скоби накрая. Винаги трябва да връщат нещо. Могат да имат и сетер. Гегера може да се задава и ръчно от нас. Специфични са за VueJS.
  methods: {
    onFilter(type) {
      if(type == 'reset') {
        this.filteredItems = [...data];
      } else {
        this.filteredItems = data.filter(i => i.type == type);
      }
    },
    addToFavourites(index) {
      const currItem = this.filteredItems[index];

      if(currItem.saved) {
        currItem.saved = false;
        this.favCount--;
      } else {
        currItem.saved = true;
        this.favCount++;
      }
    },
    generateRandomNumber() {
      this.number = Math.floor(Math.random() * 20) + 1;
    }
  }
};
</script>

<style>
  .imageList {
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    column-gap: 6px;
    row-gap: 6px;
    padding: 0;
    margin: 0;
  }

  .item {
    list-style: none;
  }

  .image {
    width: 100%;
    cursor: pointer;
  }

  .saved {
    border: 5px solid red;
    border-radius: 12px;
  }

  .controls {
    display: flex;
    justify-content: space-between;
    margin-bottom: 12px;
  }
</style>
