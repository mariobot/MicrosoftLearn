const  config = {
    user:  'tester', // sql user
    password:  '123456', //sql user password
    server:  'MBOTERO\\MBOTERO', // if it does not work try- localhost
    database:  'ProductsList',
    options: {
      trustedconnection:  true,
      enableArithAbort:  true,
      instancename:  'MBOTERO\\MBOTERO'  // SQL Server instance name
    },
    port:  1433
  }
  
  module.exports = config;
  