<?php

/* base.html.twig */
class __TwigTemplate_93e2499d03c6402ea1e3906495568257ed0120721f7f5badb0e11600e82927c5 extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        $this->parent = false;

        $this->blocks = array(
            'title' => array($this, 'block_title'),
            'stylesheets' => array($this, 'block_stylesheets'),
            'body_id' => array($this, 'block_body_id'),
            'body' => array($this, 'block_body'),
            'main' => array($this, 'block_main'),
        );
    }

    protected function doDisplay(array $context, array $blocks = array())
    {
        $__internal_1b06d7cbcd294dfb860e70a2232b8850282f91e5d4dbfc72f5d195e6cdee8957 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_1b06d7cbcd294dfb860e70a2232b8850282f91e5d4dbfc72f5d195e6cdee8957->enter($__internal_1b06d7cbcd294dfb860e70a2232b8850282f91e5d4dbfc72f5d195e6cdee8957_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "base.html.twig"));

        $__internal_9f6f6391b23de43fe82815c3f6bdff3631979e1528e74e1a0a21f46575336d3e = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_9f6f6391b23de43fe82815c3f6bdff3631979e1528e74e1a0a21f46575336d3e->enter($__internal_9f6f6391b23de43fe82815c3f6bdff3631979e1528e74e1a0a21f46575336d3e_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "base.html.twig"));

        // line 6
        echo "<!DOCTYPE html>
<html lang=\"en-US\">
<head>
    <meta charset=\"UTF-8\"/>
    <title>";
        // line 10
        $this->displayBlock('title', $context, $blocks);
        echo "</title>
    ";
        // line 11
        $this->displayBlock('stylesheets', $context, $blocks);
        // line 16
        echo "    <link rel=\"icon\" type=\"image/x-icon\" href=\"";
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("favicon.ico"), "html", null, true);
        echo "\"/>
</head>

<body id=\"";
        // line 19
        $this->displayBlock('body_id', $context, $blocks);
        echo "\">
";
        // line 20
        $this->displayBlock('body', $context, $blocks);
        // line 23
        echo "</body>
</html>
";
        
        $__internal_1b06d7cbcd294dfb860e70a2232b8850282f91e5d4dbfc72f5d195e6cdee8957->leave($__internal_1b06d7cbcd294dfb860e70a2232b8850282f91e5d4dbfc72f5d195e6cdee8957_prof);

        
        $__internal_9f6f6391b23de43fe82815c3f6bdff3631979e1528e74e1a0a21f46575336d3e->leave($__internal_9f6f6391b23de43fe82815c3f6bdff3631979e1528e74e1a0a21f46575336d3e_prof);

    }

    // line 10
    public function block_title($context, array $blocks = array())
    {
        $__internal_9c0d582219eac7efeed5a70654c4314baba5a6fe5b6e79b5fbe1a9d2a9f09596 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_9c0d582219eac7efeed5a70654c4314baba5a6fe5b6e79b5fbe1a9d2a9f09596->enter($__internal_9c0d582219eac7efeed5a70654c4314baba5a6fe5b6e79b5fbe1a9d2a9f09596_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "title"));

        $__internal_5bee9d301307efc55391d26812e42c7493b5285a9687eaf34693e62f3e6e1471 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_5bee9d301307efc55391d26812e42c7493b5285a9687eaf34693e62f3e6e1471->enter($__internal_5bee9d301307efc55391d26812e42c7493b5285a9687eaf34693e62f3e6e1471_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "title"));

        echo "Project Rider";
        
        $__internal_5bee9d301307efc55391d26812e42c7493b5285a9687eaf34693e62f3e6e1471->leave($__internal_5bee9d301307efc55391d26812e42c7493b5285a9687eaf34693e62f3e6e1471_prof);

        
        $__internal_9c0d582219eac7efeed5a70654c4314baba5a6fe5b6e79b5fbe1a9d2a9f09596->leave($__internal_9c0d582219eac7efeed5a70654c4314baba5a6fe5b6e79b5fbe1a9d2a9f09596_prof);

    }

    // line 11
    public function block_stylesheets($context, array $blocks = array())
    {
        $__internal_2760c5b4571991bc65c903c861bc8fb7ef399f2310c9fe467959277acce6c2f3 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_2760c5b4571991bc65c903c861bc8fb7ef399f2310c9fe467959277acce6c2f3->enter($__internal_2760c5b4571991bc65c903c861bc8fb7ef399f2310c9fe467959277acce6c2f3_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "stylesheets"));

        $__internal_6aafdea2f7043c758089f2e81b690b78d41adf4dbe4766be9ae758afd9913bf1 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_6aafdea2f7043c758089f2e81b690b78d41adf4dbe4766be9ae758afd9913bf1->enter($__internal_6aafdea2f7043c758089f2e81b690b78d41adf4dbe4766be9ae758afd9913bf1_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "stylesheets"));

        // line 12
        echo "        <link rel=\"stylesheet\" href=\"";
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("css/reset.css"), "html", null, true);
        echo "\">
        <link rel=\"stylesheet\" href=\"";
        // line 13
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("css/style.css"), "html", null, true);
        echo "\">
        <link rel=\"stylesheet\" href=\"";
        // line 14
        echo twig_escape_filter($this->env, $this->env->getExtension('Symfony\Bridge\Twig\Extension\AssetExtension')->getAssetUrl("css/create-style.css"), "html", null, true);
        echo "\">
    ";
        
        $__internal_6aafdea2f7043c758089f2e81b690b78d41adf4dbe4766be9ae758afd9913bf1->leave($__internal_6aafdea2f7043c758089f2e81b690b78d41adf4dbe4766be9ae758afd9913bf1_prof);

        
        $__internal_2760c5b4571991bc65c903c861bc8fb7ef399f2310c9fe467959277acce6c2f3->leave($__internal_2760c5b4571991bc65c903c861bc8fb7ef399f2310c9fe467959277acce6c2f3_prof);

    }

    // line 19
    public function block_body_id($context, array $blocks = array())
    {
        $__internal_17b6a66b895ec347d40830888a7a7b0186658d94cf2f8822f36ed61c4c2bca7d = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_17b6a66b895ec347d40830888a7a7b0186658d94cf2f8822f36ed61c4c2bca7d->enter($__internal_17b6a66b895ec347d40830888a7a7b0186658d94cf2f8822f36ed61c4c2bca7d_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "body_id"));

        $__internal_c5351914c31a9c0708ddb611ea96a0f2da64bc21389edd0270bb816431daa09a = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_c5351914c31a9c0708ddb611ea96a0f2da64bc21389edd0270bb816431daa09a->enter($__internal_c5351914c31a9c0708ddb611ea96a0f2da64bc21389edd0270bb816431daa09a_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "body_id"));

        
        $__internal_c5351914c31a9c0708ddb611ea96a0f2da64bc21389edd0270bb816431daa09a->leave($__internal_c5351914c31a9c0708ddb611ea96a0f2da64bc21389edd0270bb816431daa09a_prof);

        
        $__internal_17b6a66b895ec347d40830888a7a7b0186658d94cf2f8822f36ed61c4c2bca7d->leave($__internal_17b6a66b895ec347d40830888a7a7b0186658d94cf2f8822f36ed61c4c2bca7d_prof);

    }

    // line 20
    public function block_body($context, array $blocks = array())
    {
        $__internal_bc6fe3283b17edde5b27babe8baa1dd89cc6a1961da9460be265af89ab511886 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_bc6fe3283b17edde5b27babe8baa1dd89cc6a1961da9460be265af89ab511886->enter($__internal_bc6fe3283b17edde5b27babe8baa1dd89cc6a1961da9460be265af89ab511886_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "body"));

        $__internal_13309ff172c905ef18b2d6c6d573d1929abf0cb89d115b8fd35f94e2c0fc5144 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_13309ff172c905ef18b2d6c6d573d1929abf0cb89d115b8fd35f94e2c0fc5144->enter($__internal_13309ff172c905ef18b2d6c6d573d1929abf0cb89d115b8fd35f94e2c0fc5144_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "body"));

        // line 21
        echo "    ";
        $this->displayBlock('main', $context, $blocks);
        
        $__internal_13309ff172c905ef18b2d6c6d573d1929abf0cb89d115b8fd35f94e2c0fc5144->leave($__internal_13309ff172c905ef18b2d6c6d573d1929abf0cb89d115b8fd35f94e2c0fc5144_prof);

        
        $__internal_bc6fe3283b17edde5b27babe8baa1dd89cc6a1961da9460be265af89ab511886->leave($__internal_bc6fe3283b17edde5b27babe8baa1dd89cc6a1961da9460be265af89ab511886_prof);

    }

    public function block_main($context, array $blocks = array())
    {
        $__internal_588ccf7afa95a1ec44e2a1515493f00de193d8b95e82d217bb694250680bde6a = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_588ccf7afa95a1ec44e2a1515493f00de193d8b95e82d217bb694250680bde6a->enter($__internal_588ccf7afa95a1ec44e2a1515493f00de193d8b95e82d217bb694250680bde6a_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        $__internal_97f1a56f87abc3c385fbf79ea88ade964d61018bcee9b5cfc94c5760378ea286 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_97f1a56f87abc3c385fbf79ea88ade964d61018bcee9b5cfc94c5760378ea286->enter($__internal_97f1a56f87abc3c385fbf79ea88ade964d61018bcee9b5cfc94c5760378ea286_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        
        $__internal_97f1a56f87abc3c385fbf79ea88ade964d61018bcee9b5cfc94c5760378ea286->leave($__internal_97f1a56f87abc3c385fbf79ea88ade964d61018bcee9b5cfc94c5760378ea286_prof);

        
        $__internal_588ccf7afa95a1ec44e2a1515493f00de193d8b95e82d217bb694250680bde6a->leave($__internal_588ccf7afa95a1ec44e2a1515493f00de193d8b95e82d217bb694250680bde6a_prof);

    }

    public function getTemplateName()
    {
        return "base.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  141 => 21,  132 => 20,  115 => 19,  103 => 14,  99 => 13,  94 => 12,  85 => 11,  67 => 10,  55 => 23,  53 => 20,  49 => 19,  42 => 16,  40 => 11,  36 => 10,  30 => 6,);
    }

    /** @deprecated since 1.27 (to be removed in 2.0). Use getSourceContext() instead */
    public function getSource()
    {
        @trigger_error('The '.__METHOD__.' method is deprecated since version 1.27 and will be removed in 2.0. Use getSourceContext() instead.', E_USER_DEPRECATED);

        return $this->getSourceContext()->getCode();
    }

    public function getSourceContext()
    {
        return new Twig_Source("{#
   This is the base template used as the application layout which contains the
   common elements and decorates all the other templates.
   See http://symfony.com/doc/current/book/templating.html#template-inheritance-and-layouts
#}
<!DOCTYPE html>
<html lang=\"en-US\">
<head>
    <meta charset=\"UTF-8\"/>
    <title>{% block title %}Project Rider{% endblock %}</title>
    {% block stylesheets %}
        <link rel=\"stylesheet\" href=\"{{ asset('css/reset.css') }}\">
        <link rel=\"stylesheet\" href=\"{{ asset('css/style.css') }}\">
        <link rel=\"stylesheet\" href=\"{{ asset('css/create-style.css') }}\">
    {% endblock %}
    <link rel=\"icon\" type=\"image/x-icon\" href=\"{{ asset('favicon.ico') }}\"/>
</head>

<body id=\"{% block body_id %}{% endblock %}\">
{% block body %}
    {% block main %}{% endblock %}
{% endblock %}
</body>
</html>
", "base.html.twig", "H:\\EXAM\\PHP-Skeleton\\app\\Resources\\views\\base.html.twig");
    }
}
