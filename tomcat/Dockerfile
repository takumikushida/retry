FROM tomcat:11.0.0-jdk21
RUN apt-get update && apt-get install -y wget && apt-get install -y iproute2 && apt-get install -y vim

COPY ./demo/target/demo-0.0.1-SNAPSHOT.war /usr/local/tomcat/webapps/
# COPY ./DbContexts /usr/local/tomcat/webapps/DbContexts
# COPY ./Models /usr/local/tomcat/webapps/Modules
# COPY ./sample.war /usr/local/tomcat/webapps

EXPOSE 8080

CMD ["catalina.sh", "run"]
