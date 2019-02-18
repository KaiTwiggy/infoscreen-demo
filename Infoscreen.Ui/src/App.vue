<template>
  <div id="app">
    <InfoSlideDeck />
  </div>
</template>

<script>
import InfoSlideDeck from './components/InfoSlideDeck'

export default {
  name: 'App',
  components: {
    InfoSlideDeck
  }
}
</script>

<style>
body {
  margin: 0;
  height: 100vh;
}

#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 0px;
}

.agile__dots {
  bottom: 0;
  display: block;
  left: 10px;
  position: absolute;
  width: 30px;
}

.agile__dot {
  margin-bottom: 10px;
}

.agile__dot button {
  border: none;
  border-radius: 50%;
  cursor: pointer;
  display: block;
  height: 10px;
  font-size: 0;
  line-height: 0;
  margin: 0;
  transition-duration: 0.3s;
  width: 10px;
  background-color: hsla(0, 0%, 100%, 0.3);
}

.agile__dot--current button {
  background-color: hsla(0, 0%, 100%, 0.6);
}
</style>
