<template>
  <agile v-if="isCarouselVisible" :arrows="false" :speed="300" :timing="'linear'" :fade="true" :autoplay="true" :autoplaySpeed="6000" :pauseOnHover="false">
      <div v-for="item in slideDeck" :key="item.id">
        <component :is='item.cardType' :data='item.data'></component>
      </div>
  </agile>
</template>

<script>
import HtmlSlide from './HtmlSlide'
import ImageSlide from './ImageSlide'
import TextSlide from './TextSlide'

export default {
  name: 'InfoSlideDeck',
  components: { ImageSlide, HtmlSlide, TextSlide },
  computed: {
    slideDeck () {
      return this.$store.state.slidedeck.slides
    },
    isCarouselVisible () {
      return this.$store.state.slidedeck.isCarouselVisible
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1,
h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
