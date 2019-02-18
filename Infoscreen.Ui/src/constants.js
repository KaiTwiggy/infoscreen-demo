export const WS_BASE_URL =
  process.env.NODE_ENV !== 'production'
    ? `ws:\\${process.env.WS_BASEURL}`
    : `wss:\\${window.location.hostname}:${window.location.port}`
