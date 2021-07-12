<p align="center">
  <img src="https://github.com/nfense/ModCache/blob/main/assets/icon.png?raw=true"/>
  <h1 align="center">ModCache</h1>
  <p align="center">High performance HTTP Cache module for NProxy</p>
</p>

## ⚠️ Disclaimer

This project is still in development and is not ready for production use. This is not optimized and may be unstable. Use only in development or test environments.

## 🚀 About

ModCache is a module for [NProxy](https://github.com/nfense/NProxy) which aims to create an in-memory cache of static files so that their download is faster and more efficient.

## ⚙️ How it Works?

This project works by storing in memory the server's response when the client requests a resource. In this way, if the same resource is requested again, the copy that is in memory will be given instead of processing the response and reading or downloading the file again.

## ToDo

- [x] Create cache system based on Domain, Paths and Buffer.  
- [ ] Create expiration for cache.  
- [ ] Implement Content-Type whitelist.  
- [ ] Read buffer from response.  
