<template>
  <div >
    <HeaderBar/>
    <br/>
    <router-view/>
  </div>
</template>

<script>
import HeaderBar from './components/HeaderBar'

export default {
  name: 'App',
  components: { HeaderBar }
}
</script>

<style lang="scss">
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.has-text-green{
  color: #0B6623
}

</style>
