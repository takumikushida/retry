FROM centos:latest

RUN sed -i -e 's/^mirrorlist/#mirrorlist/g' \
           -e 's/^#baseurl=http:\/\/mirror/baseurl=http:\/\/vault/g' \
           /etc/yum.repos.d/CentOS-*.repo

RUN yum -y update && \
    yum -y install httpd && \
    yum clean all

COPY apache.conf /etc/httpd/conf/httpd.conf

RUN chmod 744 /var/log/httpd/

EXPOSE 3000
CMD ["/usr/sbin/httpd", "-D", "FOREGROUND"]