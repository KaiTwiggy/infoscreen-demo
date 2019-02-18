import Vue from 'vue'
import Vuex from 'vuex'
import slidedeck from './slidedeck/slidedeck'
import * as actions from './actions'
import Socket from 'simple-websocket'
import * as constants from '../constants.js'

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'

const store = new Vuex.Store({
  actions,
  modules: {
    slidedeck
  },
  strict: debug
})

// Not sure if this is the correct place for the websocket stuff.
// most probably not.
var socket = new Socket(constants.WS_BASE_URL + '/api/websocket')

socket.on('data', function (data) {
  const dataString = String.fromCharCode.apply(null, data)

  store.commit('hideSlides')
  store.commit('updateSlides', JSON.parse(dataString))

  // Timeout bcause if just sending events, then the slider wont refresh
  // Prolly could be done with Vue.NextTick
  setTimeout(() => store.commit('showSlides'), 1000)
})

export default store
